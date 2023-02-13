using System.ComponentModel;
using Camille.Core.Attribute;

namespace Camille.Core.Enum.MiraiWebSocket;

/// <summary>
/// 连接通道
/// </summary>
public enum ConnectChannelType
{
    [Description("推送消息")] [ContentText("message")]
    Message,

    [Description("推送事件")] [ContentText("event")]
    Event,

    [ContentText("all")] [Description("推送消息与事件")]
    All
}