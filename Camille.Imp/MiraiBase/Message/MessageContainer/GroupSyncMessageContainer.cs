using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

/// <summary>
/// 群同步消息
/// </summary>
public record GroupSyncMessageContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.GroupSyncMessage;

    /// <summary>
    /// 发送的目标群
    /// </summary>
    [JsonProperty("subject")]
    public Group Subject { get; set; }
}