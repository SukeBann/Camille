using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageReceived;

/// <summary>
/// 群临时同步消息
/// </summary>
public record TempSyncMessageReceived : SyncMessageReceivedBase
{
    public override MiraiSyncMsgChainType SyncReceiveMsgType { get; init; } = MiraiSyncMsgChainType.TempSyncMessage;

    /// <summary>
    /// 为发送的目标群成员
    /// </summary>
    [JsonProperty("subject")]
    public GroupMember Subject { get; set; }
}
