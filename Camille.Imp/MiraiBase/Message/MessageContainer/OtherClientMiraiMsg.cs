using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

public record OtherClientMiraiMsg : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.OtherClientMessage;

    /// <summary>
    /// 发送者(其他客户端)
    /// </summary>
    [JsonProperty("sender")]
    public MiraiClient Sender { get; set; }
}