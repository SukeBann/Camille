using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

public record StrangerMiraiMsgContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.StrangerMessage;

    /// <summary>
    /// 消息发送者
    /// </summary>
    [JsonProperty("sender")]
    public Account Sender { get; set; }
}