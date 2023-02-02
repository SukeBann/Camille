using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.BotEvent;

/// <summary>
/// Bot被挤下线
/// </summary>
public class BotOfflineEventForce: MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotOfflineEventForce;

    [JsonProperty("qq")]
    public long QQ { get; set; }
}