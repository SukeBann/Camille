using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.BotEvent;

/// <summary>
/// Bot被挤下线
/// </summary>
public record BotOfflineEventForce : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.BotOfflineEventForce;

    /// <summary>
    /// bot的qq
    /// </summary>
    [JsonProperty("qq")]
    public long QQ { get; set; }
}