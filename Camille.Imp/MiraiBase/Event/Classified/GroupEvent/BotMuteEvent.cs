using System.Text.Json.Serialization;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// Bot被禁言
/// </summary>
public class BotMuteEvent: MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotMuteEvent;

    /// <summary>
    /// 禁言时长, 单位:秒
    /// </summary>
    public int DurationSeconds { get; set; }

    /// <summary>
    /// 禁言时长
    /// </summary>
    [JsonIgnore]
    public TimeSpan DurationTime => TimeSpan.FromSeconds(DurationSeconds);
    
    /// <summary>
    /// 产生该事件的操作者, 绝对是管理员或者群主
    /// </summary>
    public GroupMember Operator { get; set; }
}