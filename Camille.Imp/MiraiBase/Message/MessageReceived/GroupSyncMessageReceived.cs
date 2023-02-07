using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageReceived;

/// <summary>
/// 群同步消息
/// </summary>
public record GroupSyncMessageReceived : SyncMessageReceivedBase
{
    public override MiraiSyncMsgChainType SyncReceiveMsgType { get; init; } = MiraiSyncMsgChainType.GroupSyncMessage;
    
    /// <summary>
    /// 发送的目标群
    /// </summary>
    [JsonProperty("subject")]
    public Group Subject { get; set; }
}