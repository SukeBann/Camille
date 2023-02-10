using System.Reflection;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Event;
using Camille.Imp.MiraiBase.Message;
using Camille.Imp.MiraiBase.Models;
using Camille.Imp.MiraiBase.Models.Contract;

namespace Camille.Imp.MiraiBase;

/// <summary>
/// 用于将Mirai传来的数据反射为 Camille.<see cref="Camille.Imp.MiraiBase"/> 实现的类型
/// </summary>
public static class MiraiDataReflection
{
    /// <summary>
    /// Ctor
    /// </summary>
    static MiraiDataReflection()
    {
        var eventSet
            = GetDefaultInstances<MiraiEventBase>("Camille.Imp.MiraiBase.Event.Classified");
        MiraiEventTypeMapping = GetTypeMapping<MiraiEventType, MiraiEventBase>(eventSet);
        
        var basicMsgSet
            = GetDefaultInstances<MiraiBasicMessageBase>("Camille.Imp.MiraiBase.Message.BasicMessage");
        MiraiBasicMsgTypeMapping = GetTypeMapping<MiraiBasicMsgType, MiraiBasicMessageBase>(basicMsgSet);
        
        var receiveMsg
            = GetDefaultInstances<MiraiMsgReceivedBase>("Camille.Imp.MiraiBase.Message.MessageReceived");
        MiraiReceiveMsgTypeMapping = GetTypeMapping<MiraiReceiveMsgType, MiraiMsgReceivedBase>(receiveMsg);
    }

    #region Methods

      

    #endregion

    #region Properties

    /// <summary>
    /// <see cref="MiraiEventBase"/>子类的实现类型映射
    /// </summary>
    public static Dictionary<string, IMiraiTypeMapping<MiraiEventType>> MiraiEventTypeMapping { get; }
    
    /// <summary>
    /// <see cref="MiraiMsgReceivedBase"/>子类的实现类型映射
    /// </summary>
    public static Dictionary<string, IMiraiTypeMapping<MiraiReceiveMsgType>> MiraiReceiveMsgTypeMapping { get; }
    
    /// <summary>
    /// <see cref="MiraiBasicMessageBase"/>子类的实现类型映射
    /// </summary>
    public static Dictionary<string, IMiraiTypeMapping<MiraiBasicMsgType>> MiraiBasicMsgTypeMapping { get; }


    #endregion

    #region Private

    /// <summary>
    /// 获取对应Mirai类型的Type映射字典
    ///  <br/> key: 对应标识类型的字符串文本 例如: <see cref="MiraiEventType.NudgeEvent"/>
    ///  <br/> value: 对应的<see cref="IMiraiTypeMapping{T}"/>的实现
    ///  <br/> 例如: <see cref="MiraiEventTypeMapping"/> or <see cref="MiraiBasicMsgTypeMapping"/> and <see cref="MiraiReceiveMsgType"/>
    /// </summary>
    /// <typeparam name="T"><see cref="MiraiEventType"/> or <see cref="MiraiBasicMsgType"/> or <see cref="MiraiReceiveMsgType"/></typeparam>
    /// <typeparam name="TI">实例类型</typeparam>
    /// <returns></returns>
    private static Dictionary<string, IMiraiTypeMapping<T>> GetTypeMapping<T, TI>(IEnumerable<TI> instanceSet)
        where T : Enum
        where TI : class
    {
        if (typeof(T) != typeof(MiraiBasicMsgType) &&
            typeof(T) != typeof(MiraiEventType) &&
            typeof(T) != typeof(MiraiReceiveMsgType))
        {
            throw new ArgumentException("该方法不支持此枚举类型使用", $"{typeof(T).FullName}");
        }

        var miraiTypeDict = new Dictionary<string, IMiraiTypeMapping<T>>();

        foreach (var instance in instanceSet)
        {
            var miraiTypeMapping = GetTypeMapping<T, TI>(instance);
            miraiTypeDict.TryAdd(miraiTypeMapping.MiraiTypeName, miraiTypeMapping);
        }

        return miraiTypeDict;
    }

    /// <summary>
    /// 获取对应实例的 类型映射<see cref="IMiraiTypeMapping{T}"/>
    /// </summary>
    /// <param name="instance">类型实例</param>
    /// <typeparam name="T"><see cref="MiraiEventType"/> or <see cref="MiraiBasicMsgType"/> or <see cref="MiraiReceiveMsgType"/></typeparam>
    /// <typeparam name="TI">实例类型</typeparam>
    /// <returns></returns>
    private static IMiraiTypeMapping<T> GetTypeMapping<T, TI>(TI instance)
        where T : Enum
    {
        return instance switch
        {
            MiraiBasicMessageBase basicMessageBase => (IMiraiTypeMapping<T>) new MiraiBasicMsgTypeMapping(
                basicMessageBase.MiraiBasicMsgType, 
                basicMessageBase.MiraiBasicMsgType.ToString(),
                basicMessageBase.GetType()),
            
            MiraiMsgReceivedBase messageReceivedBase => (IMiraiTypeMapping<T>) new MiraiMsgReceivedTypeMapping(
                messageReceivedBase.ReceiveMsgType,
                messageReceivedBase.ReceiveMsgType.ToString(),
                messageReceivedBase.GetType()),
            
            MiraiEventBase miraiEventBase => (IMiraiTypeMapping<T>) new MiraiEventTypeMapping(
                miraiEventBase.EventType,
                miraiEventBase.EventType.ToString(),
                miraiEventBase.GetType()),
            
            _ => throw new ArgumentException("该方法不支持此类型使用！", typeof(TI).FullName)
        };
    }

    /// <summary>
    /// 这个方法是从Mirai.NET抄的, 连注释也是抄的^^
    /// 获取某个命名空间下所有类的默认实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    private static IEnumerable<T> GetDefaultInstances<T>(string @namespace) where T : class
    {
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.FullName is not null && type.FullName.Contains(@namespace))
            .Where(type => !type.IsAbstract)
            .Select(type =>
            {
                if (Activator.CreateInstance(type) is T instance)
                {
                    return instance;
                }

                return null;
            })
            // 这里判断了 x is not null 但是idea依旧提示返回 T? 所以使用感叹号让他闭嘴
            .Where(x => x is not null)!;
    }

    #endregion
}