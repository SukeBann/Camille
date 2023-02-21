using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBot;

/// <summary>
/// 发送消息或进行api调用的 接口适配器类型
/// </summary>
public enum ApiAdapterType
{
    /// <summary>
    /// http请求
    /// </summary>
    Http,
    
    /// <summary>
    /// 提供基于 websocket server 的接口
    /// </summary>
    Websocket,
    
    /// <summary>
    /// 提供基于 websocket client 的接口
    /// </summary>
    ReverseWebsocket,
    
    /// <summary>
    /// 提供 http 回调形式的接口, 可单纯做上报使用
    /// https://docs.mirai.mamoe.net/mirai-api-http/adapter/WebhookAdapter.html
    /// </summary>
    WeHook
}