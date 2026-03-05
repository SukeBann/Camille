using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

/// <summary>
/// 好友同步消息
/// </summary>
public record FriendSyncMessageContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.FriendSyncMessage;

    /// <inheritdoc />
    public override Account? Sender { get; set; }
}