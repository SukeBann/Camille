using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// Bot被禁言
/// </summary>
public record BotMuteEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.BotMuteEvent;

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
    /// 产生该事件的操作者, 绝对是管理员或者群主
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember Operator { get; set; }
}