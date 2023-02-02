using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群允许群员邀请好友功能变更
/// </summary>
public class GroupAllowMemberInviteEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.GroupAllowMemberInviteEvent;

    /// <summary>
    /// 原本是否允许群员邀请好友状态是否开启
    /// </summary>
    [JsonProperty("origin")]
    public bool Origin { get; set; }

    /// <summary>
    /// 现在是否允许群员邀请好友状态是否开启
    /// </summary>
    [JsonProperty("current")]
    public bool Current { get; set; }

    /// <summary>
    /// 是否允许群员邀请好友状态发生改变的群信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 操作者, 当为null时为bot操作
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember? Operator { get; set; }
}