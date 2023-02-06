using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Message.MessageChainType;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageChainType;

/// <summary>
/// 好友发来的消息
/// </summary>
public class FriendMessage: MessageChainBase
{
    public override MiraiMsgChainType MsgChainType { get; set; } = MiraiMsgChainType.FriendMessage;

    /// <summary>
    /// 消息发送者
    /// </summary>
    [JsonProperty("sender")]
    public Friend Sender { get; set; }
}