using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

/// <summary>
/// 好友发来的消息
/// </summary>
public record FriendMiraiMsgContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.FriendMessage;

    /// <summary>
    /// 消息发送者
    /// </summary>
    [JsonProperty("sender")]
    public Account Sender { get; set; }
}