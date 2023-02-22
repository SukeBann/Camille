using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

public record StrangerSyncMessageContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.StrangerSyncMessage;

    /// <summary>
    /// 发送消息的陌生人账号
    /// </summary>
    [JsonProperty("subject")]
    public Account Subject { get; set; }
}