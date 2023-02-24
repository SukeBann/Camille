using System.Reactive.Subjects;
using Camille.Core.Adapter;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Shared.Extension;
using Newtonsoft.Json.Linq;

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
        var dataJToken = data.GetJsonValue<JToken>("data");
        if (dataJToken is null)
        {
            return;
        }
        if (dataJToken.TryGetValue<string>("type", out var value) && !value.Equals(""))
        {
            GetEventOrMsg(dataJToken.ToString(), value);
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
                var miraiEvent = MiraiDataReflection.GetMiraiEvent(typeString, json);
                OnMiraiEventReceived.OnNext(miraiEvent);
                break;
            case MiraiDataType.Message:
                var miraiMessage = MiraiDataReflection.GetMiraiReceivedMessage(typeString, json);
                OnMiraiMessageReceived.OnNext(miraiMessage);
                break;
            case MiraiDataType.Unknown:
            default:
                var ex = new ArgumentOutOfRangeException(nameof(typeString), $"未知消息类型: {typeString}");
                Shared.Logger.Error("获取Mirai数据类型时发生错误, 目标消息为未知类型", ex);
                return;
        }
    }

    #endregion

    #region Publish

    /// <inheritdoc/>
    public Subject<IMiraiEvent> OnMiraiEventReceived { get; init; }

    /// <inheritdoc/>
    public Subject<IMiraiMessageContainer> OnMiraiMessageReceived { get; init; }

    #endregion
}