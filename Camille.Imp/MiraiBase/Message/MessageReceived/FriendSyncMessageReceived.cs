using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageReceived;

/// <summary>
/// 好友同步消息
/// </summary>
public record FriendSyncMessageReceived: SyncMessageReceivedBase
{
    public override MiraiSyncMsgChainType SyncReceiveMsgType { get; set; } = MiraiSyncMsgChainType.FriendSyncMessage;

    /// <summary>
    /// 好友
    /// </summary>
    [JsonProperty("subject")]
    public Account Subject { get; set; }
}