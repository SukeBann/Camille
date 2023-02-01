using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// Mirai同步消息链类型,
/// 同步消息和普通消息一样, 但是由 Bot 账号的其他客户端发送的消息, 同步到 mirai 时产生的事件. 此类事发送人永远是 Bot 本身, 故省略
/// </summary>
public enum MiraiSyncMsgChainType
{
    [Description("同步好友消息")]
    FriendSyncMessage,
    [Description("同步群消息")]
    GroupSyncMessage,
    [Description("同步临时消息")]
    TempSyncMessage,
    [Description("同步陌生人消息")]
    StrangerSyncMessage
}