using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBot;

/// <summary>
/// 消息与事件接收的适配器
/// </summary>
public enum ReceiveAdapterType
{
    /// <summary>
    /// http adapter 基于缓存队列保存 session 的"未读消息", 消息与事件的接收，等同于对该队列的操作.
    /// <br/> https://docs.mirai.mamoe.net/mirai-api-http/adapter/HttpAdapter.html
    /// </summary>
    Http,

    /// <summary>
    /// ws adatper 通过 websocket 主动推送消息与事件
    /// <br/> ws adatper 拥有三个连接通道
    /// <br/> /message: 推送消息
    /// <br/> /event: 推送事件
    /// <br/> /all: 推送消息及事件
    /// <br/> https://docs.mirai.mamoe.net/mirai-api-http/adapter/WebsocketAdapter.html
    /// </summary>
    Websocket,

    /// <summary>
    /// reverse-ws adatper 通过 websocket 链接远端 websocket server 后, 主动推送消息与事件
    /// <br/> 在配置文件中配置正确的 远端 websocket server 地址
    /// <br/> 远端 websocket server 建立通信后, 通过 websocket server 发起认证请求
    /// <br/> https://docs.mirai.mamoe.net/mirai-api-http/adapter/ReverseWebsocketAdapter.html
    /// </summary>
    ReverseWebsocket,
}