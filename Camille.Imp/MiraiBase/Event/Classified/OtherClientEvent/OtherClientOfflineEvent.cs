using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.OtherClientEvent;

/// <summary>
/// 其他客户端离线
/// </summary>
public record OtherClientOfflineEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.OtherClientOfflineEvent;
    
    /// <summary>
    /// 其他客户端信息
    /// </summary>
    [JsonProperty("client")]
    public MiraiClient Client { get; set; } 
}