using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.BotEvent;

/// <summary>
/// Bot主动离线
/// </summary>
public record BotOfflineEventActive : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.BotOfflineEventActive;

    /// <summary>
    /// bot的qq
    /// </summary>
    [JsonProperty("qq")]
    public long QQ { get; set; }
}