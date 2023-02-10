using System.Globalization;
using System.Reactive.Subjects;
using Camille.Client.Extension;
using Camille.Core.Adapter;
using Camille.Core.MiraiBase;
using Camille.Logger;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Camille.Imp.MiraiBase;

public class MiraiEventMsgParser : IMiraiEventMsgParser
{
    #region Properties

    public ILogger Logger { get; set; } 
    
    #endregion
    
    public void BeginParseData(IReceiveDataPublisher dataSender)
    {
        dataSender.OnWsReceiveMsg.Subscribe(ParseData);
    }

    #region Method

    private void ParseData(string data)
    {
        if (!data.TryGetJObject(out var jToken)) return;

        if (!jToken.TryGetJObject(out var jObject)) return;

        if (jObject.TryGetValue("type", out var value))
        {
            
        }
        else
        {
            Logger.Debug($"收到无法解析的信息: {data}"); 
        }
    }

    /// <summary>
    /// 尝试从type获取对应的mirai事件
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="json">接受到的json数据</param>
    /// <param name="miraiEvent">成功获取事件时out event, 没有获取到时out null</param>
    /// <returns>成功获取返回true, 获取失败返回false</returns>
    private bool TryGetMiraiEvent(string type, string json, out IMiraiEvent? miraiEvent)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 尝试从type获取对应的mirai信息
    /// </summary>
    /// <param name="type">类型</param>
    /// <param name="json">接受到的json数据</param>
    /// <param name="miraiMessageReceived">成功获取事件时out message, 没有获取到时out null</param>
    /// <returns>成功获取返回true, 获取失败返回false</returns>
    private bool TryGetMiraiMessage(string type, string json, out IMiraiMessageReceived? miraiMessageReceived)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region Publish

    /// <inheritdoc/>
    public Subject<IMiraiEvent> OnMiraiEventReceived { get; set; }

    /// <inheritdoc/>
    public Subject<IMiraiMessageReceived> OnMiraiMessageReceived { get; set; }

    #endregion
}