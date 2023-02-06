using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 新人入群事件
/// </summary>
public record MemberJoinEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.MemberJoinEvent;

    /// <summary>
    /// 邀请者
    /// </summary>
    [JsonProperty("invitor")]
    public GroupMember Invitor { get; set; }

    /// <summary>
    /// 入群的成员信息
    /// </summary>
    [JsonProperty("member")]
    public GroupMember Member { get; set; }
}