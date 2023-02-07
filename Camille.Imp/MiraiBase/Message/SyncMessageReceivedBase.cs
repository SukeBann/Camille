using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message;

/// <summary>
/// 收到的同步消息基类
/// </summary>
public record SyncMessageReceivedBase: IMiraiSyncMessageReceived
{
    /// <summary>
    /// 同步消息类型
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiSyncMsgChainType SyncReceiveMsgType { get; set; }
    
    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("messageChain")]
    public MessageChain MessageChain { get; set; }
}