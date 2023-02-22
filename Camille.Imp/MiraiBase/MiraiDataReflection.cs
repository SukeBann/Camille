using System.Diagnostics;
using System.Reflection;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Contract;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Imp.MiraiBase.Event;
using Camille.Imp.MiraiBase.Message;
using Camille.Shared.Extension;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase;

/// <summary>
/// 用于将Mirai传来的数据反射为 Camille.<see cref="Camille.Imp.MiraiBase"/> 实现的类型
/// </summary>
/// TODO 如果此类引用的地方不多, 可以考虑改为非静态的单例
public static class MiraiDataReflection
{
    /// <summary>
    /// Ctor
    /// </summary>
    static MiraiDataReflection()
    {
        // TODO 我认为以下的命名空间硬编码存在一定的隐患, 后期需要寻找可以替代的解决方案
        var eventSet
            = GetDefaultInstances<MiraiEventBase>("Camille.Imp.MiraiBase.Event.Classified");
        MiraiEventTypeMapping = GetTypeMapping<MiraiEventType, MiraiEventBase>(eventSet);

        var basicMsgSet
            = GetDefaultInstances<MiraiBasicMessageBase>("Camille.Core.MiraiBase.Models.BasicMessage", typeof(MiraiBasicMessageBase));
        MiraiBasicMsgTypeMapping = GetTypeMapping<MiraiBasicMsgType, MiraiBasicMessageBase>(basicMsgSet);

        var receiveMsg
            = GetDefaultInstances<MiraiMsgContainerBase>("Camille.Imp.MiraiBase.Message.MessageContainer");
        MiraiMsgContainerTypeMapping = GetTypeMapping<MiraiContainerMsgType, MiraiMsgContainerBase>(receiveMsg);
    }

    #region Methods

    /// <summary>
    /// 根据类型文本获取是事件类型还是消息类型
    /// <br/> 由于大部分情况消息数量比事件多， 所以优先判断是否为消息, 然后在判断是否为事件, 如果都不是则返回<see cref="MiraiDataType.Unknown"/>
    /// </summary>
    /// <param name="typeString">类型文本</param>
    /// <returns></returns>
    public static MiraiDataType GetMiraiDataType(string typeString)
    {
        if (MiraiMsgContainerTypeMapping.ContainsKey(typeString))
        {
            return MiraiDataType.Message;
        }

        return MiraiEventTypeMapping.ContainsKey(typeString) ? MiraiDataType.Event : MiraiDataType.Unknown;
    }

    /// <summary>
    /// 根据类型标识, 将json文本转换为对应的事件实例
    /// </summary>
    /// <param name="typeString">类型标识文本</param>
    /// <param name="data">json文本</param>
    /// <returns>解析成功时返回对应类型的事件， 否则返回未知事件</returns>
    public static IMiraiEvent GetMiraiEvent(string typeString, string data)
    {
        if (!MiraiEventTypeMapping.TryGetValue(typeString, out var typeMapping))
        {
            Shared.Logger.Error($"接收到未知事件: {data}");
            return new UnKnownEvent {SourceData = data};
        }

        try
        {
            var miraiEvent = JsonConvert.DeserializeObject(data, typeMapping.InstanceType) as IMiraiEvent;
            miraiEvent.IfNullThenThrowException(out var returnValue);
            return returnValue;
        }
        catch (Exception e)
        {
            Shared.Logger.Error($"反序列化时失败或, 接收到未知事件: {data}", e);
            return new UnKnownEvent {SourceData = data};
        }
    }

    /// <summary>
    /// 根据类型标识, 将json文本转换为对应的消息实例
    /// </summary>
    /// <param name="typeString">类型标识文本</param>
    /// <param name="data">json文本</param>
    /// <returns>解析成功时返回对应类型的消息， 否则返回未知消息</returns>
    public static IMiraiMessageContainer GetMiraiReceivedMessage(string typeString, string data)
    {
        if (!MiraiMsgContainerTypeMapping.TryGetValue(typeString, out var typeMapping))
        {
            Shared.Logger.Error($"接收到未知消息: {data}");
            return new UnKnownContainerMsg {SourceData = data};
        }

        try
        {
            var receivedMsg = JsonConvert.DeserializeObject(data, typeMapping.InstanceType) as IMiraiMessageContainer;
            receivedMsg.IfNullThenThrowException(out var returnValue);
            return returnValue;
        }
        catch (Exception e)
        {
            Shared.Logger.Error($"反序列化时失败或, 接收到未知消息: {data}", e);
            return new UnKnownContainerMsg() {SourceData = data};
        }
    }

    #endregion

    #region Properties

    /// <summary>
    /// <see cref="MiraiEventBase"/>子类的实现类型映射
    /// </summary>
    private static Dictionary<string, IMiraiTypeMapping<MiraiEventType>> MiraiEventTypeMapping { get; }

    /// <summary>
    /// <see cref="MiraiMsgContainerBase"/>子类的实现类型映射
    /// </summary>
    private static Dictionary<string, IMiraiTypeMapping<MiraiContainerMsgType>> MiraiMsgContainerTypeMapping { get; }

    /// <summary>
    /// <see cref="MiraiBasicMessageBase"/>子类的实现类型映射
    /// </summary>
    internal static Dictionary<string, IMiraiTypeMapping<MiraiBasicMsgType>> MiraiBasicMsgTypeMapping { get; }

    #endregion

    #region Private

    /// <summary>
    /// 获取对应Mirai类型的Type映射字典
    ///  <br/> key: 对应标识类型的字符串文本 例如: <see cref="MiraiEventType.NudgeEvent"/>
    ///  <br/> value: 对应的<see cref="IMiraiTypeMapping{T}"/>的实现
    ///  <br/> 例如: <see cref="MiraiEventTypeMapping"/> or <see cref="MiraiBasicMsgTypeMapping"/> and <see cref="MiraiContainerMsgType"/>
    /// </summary>
    /// <typeparam name="T"><see cref="MiraiEventType"/> or <see cref="MiraiBasicMsgType"/> or <see cref="MiraiContainerMsgType"/></typeparam>
    /// <typeparam name="TI">实例类型</typeparam>
    /// <returns></returns>
    private static Dictionary<string, IMiraiTypeMapping<T>> GetTypeMapping<T, TI>(IEnumerable<TI> instanceSet)
        where T : Enum
        where TI : class
    {
        if (typeof(T) != typeof(MiraiBasicMsgType) &&
            typeof(T) != typeof(MiraiEventType) &&
            typeof(T) != typeof(MiraiContainerMsgType))
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
    /// <typeparam name="T"><see cref="MiraiEventType"/> or <see cref="MiraiBasicMsgType"/> or <see cref="MiraiContainerMsgType"/></typeparam>
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

            MiraiMsgContainerBase messageReceivedBase => (IMiraiTypeMapping<T>) new MiraiMsgContainerTypeMapping(
                messageReceivedBase.ContainerMsgType,
                messageReceivedBase.ContainerMsgType.ToString(),
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
    /// <param name="typeNamespace">类型所在的命名空间</param>
    /// <param name="assemblyInstanceType">类型所在的程序集中的任意一个类的Type</param>
    /// <returns></returns>
    private static IEnumerable<T> GetDefaultInstances<T>(string typeNamespace, Type? assemblyInstanceType = default) where T : class
    {
        var assembly = assemblyInstanceType is null ? Assembly.GetExecutingAssembly() : Assembly.GetAssembly(assemblyInstanceType);
        return assembly 
            .GetTypes()
            .Where(type => type.FullName is not null && type.FullName.Contains(typeNamespace))
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