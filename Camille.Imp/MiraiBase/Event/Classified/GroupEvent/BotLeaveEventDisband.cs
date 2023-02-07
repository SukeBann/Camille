using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 机器人因为群主解散群而退群
/// </summary>
public record BotLeaveEventDisband : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.BotLeaveEventDisband;

    /// <summary>
    /// 被解散的群
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 产生该事件的操作者, 绝对是群主
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember Operator { get; set; }
}