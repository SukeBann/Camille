using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// Bot主动退出一个群
/// </summary>
public record BotLeaveEventActive : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.BotLeaveEventActive;

    /// <summary>
    /// 退出的群的信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }
}