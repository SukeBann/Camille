using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageReceived;

/// <summary>
/// 好友发来的消息
/// </summary>
public record FriendMessageReceived: MessageReceivedBase
{
    public override MiraiReceiveMsgType ReceiveMsgType { get; set; } = MiraiReceiveMsgType.FriendMessage;

    /// <summary>
    /// 消息发送者
    /// </summary>
    [JsonProperty("sender")]
    public Account Sender { get; set; }
}