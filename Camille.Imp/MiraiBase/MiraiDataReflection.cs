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
    static MiraiDataReflection()
    {
        var eventSet
            = GetDefaultInstances<MiraiEventBase>("Camille.Imp.MiraiBase.Event.Classified");
        MiraiEventTypeMapping = GetTypeMapping<MiraiEventType, MiraiEventBase>(eventSet);
    }

    #region Properties

    public static Dictionary<string, IMiraiTypeMapping<MiraiEventType>> MiraiEventTypeMapping { get; }

    #endregion

    #region Private

    /// <summary>
    /// 获取对应Mirai类型的Type映射字典
    ///  <br/> key: 对应标识类型的字符串文本 例如: <see cref="MiraiEventType.NudgeEvent"/>
    ///  <br/> value: 对应的<see cref="IMiraiTypeMapping{T}"/>的实现
    ///  <br/> 例如: <see cref="MiraiEventTypeMapping"/> or <see cref="MiraiBasicMsgTypeMapping"/> and <see cref="MiraiReceiveMsgType"/>
    /// </summary>
    /// <typeparam name="T"><see cref="MiraiEventType"/> or <see cref="MiraiMsgType"/> or <see cref="MiraiReceiveMsgType"/></typeparam>
    /// <typeparam name="I">实例类型</typeparam>
    /// <returns></returns>
    private static Dictionary<string, IMiraiTypeMapping<T>> GetTypeMapping<T, I>(IEnumerable<I> instanceSet)
        where T : Enum
        where I : class
    {
        if (typeof(T) != typeof(MiraiMsgType) &&
            typeof(T) != typeof(MiraiEventType) &&
            typeof(T) != typeof(MiraiReceiveMsgType))
        {
            throw new ArgumentException("该方法不支持此枚举类型使用", $"{typeof(T).FullName}");
        }

        var miraiTypeDict = new Dictionary<string, IMiraiTypeMapping<T>>();

        foreach (var instance in instanceSet)
        {
            var miraiTypeMapping = GetTypeMapping<T, I>(instance);
            miraiTypeDict.TryAdd(miraiTypeMapping.MiraiTypeName, miraiTypeMapping);
        }

        return miraiTypeDict;
    }

    /// <summary>
    /// 获取对应实例的 类型映射<see cref="IMiraiTypeMapping{T}"/>
    /// </summary>
    /// <param name="instance">类型实例</param>
    /// <typeparam name="T"><see cref="MiraiEventType"/> or <see cref="MiraiMsgType"/> or <see cref="MiraiReceiveMsgType"/></typeparam>
    /// <typeparam name="I">实例类型</typeparam>
    /// <returns></returns>
    private static IMiraiTypeMapping<T> GetTypeMapping<T, I>(I instance)
        where T : Enum
    {
        return instance switch
        {
            BasicMessageBase basicMessageBase => (IMiraiTypeMapping<T>) new MiraiBasicMsgTypeMapping()
            {
                IdentityType = basicMessageBase.MiraiMsgType,
                MiraiTypeName = basicMessageBase.MiraiMsgType.ToString(),
                InstanceType = basicMessageBase.GetType() 
            },
            MessageReceivedBase messageReceivedBase => (IMiraiTypeMapping<T>) new MiraiMsgReceivedTypeMapping()
            {
                IdentityType = messageReceivedBase.ReceiveMsgType,
                MiraiTypeName = messageReceivedBase.ReceiveMsgType.ToString(),
                InstanceType = messageReceivedBase.GetType() 
            },
            MiraiEventBase miraiEventBase => (IMiraiTypeMapping<T>) new MiraiEventTypeMapping()
            {
                IdentityType = miraiEventBase.EventType,
                MiraiTypeName = miraiEventBase.EventType.ToString(),
                InstanceType = miraiEventBase.GetType() 
            },
            _ => throw new ArgumentException("该方法不支持此类型使用！", typeof(I).FullName)
        };
    }

    /// <summary>
    /// 这个方法是从Mirai.NET抄的, 连注释也是抄的^^
    /// 获取某个命名空间下所有类的默认实例
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    internal static IEnumerable<T> GetDefaultInstances<T>(string @namespace) where T : class
    {
        return Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(type => type.FullName != null)
            .Where(type => type.FullName.Contains(@namespace))
            .Where(type => !type.IsAbstract)
            .Select(type =>
            {
                if (Activator.CreateInstance(type) is T instance)
                {
                    return instance;
                }

                return null;
            })
            .Where(i => i != null);
    }

    #endregion
}