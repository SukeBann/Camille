using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// Mirai 消息链类型
/// https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html#%E6%B6%88%E6%81%AF%E9%93%BE%E7%B1%BB%E5%9E%8B
/// </summary>
public enum MiraiMsgChainType
{
    [Description("好友消息")]
    FriendMessage,
    [Description("群消息")]
    GroupMessage,
    [Description("群临时")]
    TempMessage,
    [Description("陌生人消息")]
    StrangerMessage,
    [Description("其他客户端消息")]
    OtherClientMessage
}