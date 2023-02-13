using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// Mirai 收到的消息类型
/// https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html#%E6%B6%88%E6%81%AF%E9%93%BE%E7%B1%BB%E5%9E%8B
/// </summary>
public enum MiraiContainerMsgType
{
    #region Msg

    [Description("好友消息")] FriendMessage,
    [Description("群消息")] GroupMessage,
    [Description("群临时")] TempMessage,
    [Description("陌生人消息")] StrangerMessage,
    [Description("其他客户端消息")] OtherClientMessage,

    #endregion

    /** 
        Mirai同步消息链类型,
        同步消息和普通消息一样, 但是由 Bot 账号的其他客户端发送的消息, 同步到 mirai 时产生的事件. 此类事发送人永远是 Bot 本身, 故省略
    */

    #region SyncMsg

    [Description("同步好友消息")] FriendSyncMessage,
    [Description("同步群消息")] GroupSyncMessage,
    [Description("同步临时消息")] TempSyncMessage,
    [Description("同步陌生人消息")] StrangerSyncMessage,

    #endregion

    [Description("无法解析的消息接收类型")] UnKnown
}