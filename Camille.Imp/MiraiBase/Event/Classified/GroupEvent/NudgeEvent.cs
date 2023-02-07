using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.FriendEvent;

/// <summary>
/// 戳一戳事件
/// </summary>
public record NudgeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.NudgeEvent;

    /// <summary>
    /// 动作发出者的qq
    /// </summary>
    [JsonProperty("fromId")]
    public long FromId { get; set; }

    /// <summary>
    /// 动作的来源
    /// </summary>
    [JsonProperty("subject")]
    public MiraiSubject EventSubject { get; set; }

}