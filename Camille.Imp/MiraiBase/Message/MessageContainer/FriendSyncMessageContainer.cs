using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

/// <summary>
/// 好友同步消息
/// </summary>
public record FriendSyncMessageContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.FriendSyncMessage;

    /// <summary>
    /// 好友
    /// </summary>
    [JsonProperty("subject")]
    public Account Subject { get; set; }
}