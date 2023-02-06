using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 成员被踢出群（该成员不是Bot）
/// </summary>
public class MemberLeaveEventKick : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.MemberLeaveEventKick;

    /// <summary>
    /// 被踢出的群员信息
    /// </summary>
    [JsonProperty("group")]
    public GroupMember Member { get; set; }

    /// <summary>
    /// 产生该事件的操作者, 绝对是群主或管理员, 如果为bot操作则为null
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember? Operator { get; set; }
}