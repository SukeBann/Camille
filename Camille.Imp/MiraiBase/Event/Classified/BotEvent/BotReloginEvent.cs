using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.BotEvent;

/// <summary>
/// Bot主动重新登录
/// </summary>
public record BotReloginEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotReloginEvent;

    /// <summary>
    /// bot的qq
    /// </summary>
    [JsonProperty("qq")]
    public long QQ { get; set; }
}