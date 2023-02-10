using System.Reactive.Subjects;
using Camille.Core.Adapter;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 将Websocket收到的文本数据解析为
/// <br/>事件<see cref="IMiraiEvent"/>或消息<see cref="IMiraiMessageReceived"/>类型
/// <br/>并通过Rx将信息或事件向订阅者发布通知
/// </summary>
public interface IMiraiEventMsgParser
{
    /// <summary>
    /// 收到新的Mirai事件
    /// </summary>
    public Subject<IMiraiEvent> OnMiraiEventReceived { get; init; }
    
    /// <summary>
    /// 收到新的Mirai信息
    /// </summary>
    public Subject<IMiraiMessageReceived> OnMiraiMessageReceived { get; init; }

    /// <summary>
    /// 开始解析收到的数据, 需要在这个方法里面实现订阅消息接收器发出的数据,
    /// <br/> 并且设置解析数据的方法, 并通过<see cref="OnMiraiEventReceived"/>和<see cref="OnMiraiMessageReceived"/>将数据传播出去
    /// </summary>
    /// <param name="dataSender">数据发送者</param>
    public void BeginParseData(IReceiveDataPublisher dataSender);
}