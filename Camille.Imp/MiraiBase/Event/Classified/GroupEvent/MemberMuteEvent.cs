using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群成员被禁言事件（该成员不是Bot）
/// </summary>
public record MemberMuteEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.MemberMuteEvent;

    /// <summary>
    /// 禁言时长, 单位:秒
    /// </summary>
    [JsonProperty("durationSeconds")]
    public int DurationSeconds { get; set; }

    /// <summary>
    /// 禁言时长
    /// </summary>
    [JsonIgnore]
    public TimeSpan DurationTime => TimeSpan.FromSeconds(DurationSeconds);

    /// <summary>
    /// 被禁言的群员信息
    /// </summary>
    [JsonProperty("group")]
    public GroupMember Member { get; set; }

    /// <summary>
    /// 产生该事件的操作者, 绝对是群主或管理员, 如果为bot操作则为null
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember? Operator { get; set; }
}