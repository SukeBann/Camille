using System.Reactive.Subjects;
using Camille.Core.Adapter;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Shared.Extension;

namespace Camille.Imp.MiraiBase;

/// <inheritdoc />
public class MiraiWsEventMsgParser : IMiraiEventMsgParser
{
    #region Ctor

    public MiraiWsEventMsgParser()
    {
        OnMiraiEventReceived = new Subject<IMiraiEvent>();
        OnMiraiMessageReceived = new Subject<IMiraiMessageContainer>();
    }

    #endregion

    public void BeginParseData(IReceiveDataPublisher dataSender)
    {
        dataSender.OnWsReceiveMsg.Subscribe(ParseData);
    }

    #region Method

    /// <summary>
    /// 解析收到的数据, 是否为json, 并进一步解析数据类型
    /// </summary>
    /// <param name="data"></param>
    private void ParseData(string data)
    {
        if (!data.TryGetJToken(out var jToken)) return;

        if (!jToken.TryGetJObject(out var jObject)) return;

        if (!jObject.TryGetValue("data", out var jData)) return;

        if (!jData.TryGetJObject(out var dataValue)) return;

        if (dataValue.TryGetValue<string>("type", out var value) && !value.Equals(""))
        {
            GetEventOrMsg(jData.ToString(), value);
        }
        else
        {
            Shared.Logger.Error($"收到无法解析的信息: {data}");
        }
    }

    /// <summary>
    /// 解析收到的数据是事件还是消息, 如果有对应的解析结果就推送订阅
    /// <br/> 优先解析是否为消息, 再解析是否为
    /// </summary>
    /// <param name="json">数据的json文本</param>
    /// <param name="typeString">数据类型文本</param>
    private void GetEventOrMsg(string json, string typeString)
    {
        var miraiDataType = MiraiDataReflection.GetMiraiDataType(typeString);
        switch (miraiDataType)
        {
            case MiraiDataType.Event:
                var miraiEvent = TryGetMiraiEvent(typeString, json);
                OnMiraiEventReceived.OnNext(miraiEvent);
                break;
            case MiraiDataType.Message:
                var miraiMessage = TryGetMiraiMessage(typeString, json);
                OnMiraiMessageReceived.OnNext(miraiMessage);
                break;
            case MiraiDataType.Unknown:
            default:
                var ex = new ArgumentOutOfRangeException(nameof(typeString), $"未知消息类型: {typeString}");
                Shared.Logger.Error("获取Mirai数据类型时发生错误, 目标消息为未知类型", ex);
                return;
        }
    }

    /// <summary>
    /// 尝试从事件类型 获取对应的mirai事件
    /// </summary>
    /// <param name="eventType">事件类型</param>
    /// <param name="json">接受到的json数据</param>
    /// <returns>成功获取返回true, 获取失败返回false</returns>
    private IMiraiEvent TryGetMiraiEvent(string eventType, string json)
    {
        return MiraiDataReflection.GetMiraiEvent(eventType, json);
    }

    /// <summary>
    /// 尝试从type获取对应的mirai信息
    /// </summary>
    /// <param name="msgType">信息类型</param>
    /// <param name="json">接受到的json数据</param>
    /// <returns>成功获取返回true, 获取失败返回false</returns>
    private IMiraiMessageContainer TryGetMiraiMessage(string msgType, string json)
    {
        return MiraiDataReflection.GetMiraiReceivedMessage(msgType, json);
    }

    #endregion

    #region Publish

    /// <inheritdoc/>
    public Subject<IMiraiEvent> OnMiraiEventReceived { get; init; }

    /// <inheritdoc/>
    public Subject<IMiraiMessageContainer> OnMiraiMessageReceived { get; init; }

    #endregion
}