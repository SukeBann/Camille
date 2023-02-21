using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

/// <summary>
/// 群临时同步消息
/// </summary>
public record TempSyncMessageContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.TempSyncMessage;

    /// <summary>
    /// 为发送的目标群成员
    /// </summary>
    [JsonProperty("subject")]
    public GroupMember Subject { get; set; }
}