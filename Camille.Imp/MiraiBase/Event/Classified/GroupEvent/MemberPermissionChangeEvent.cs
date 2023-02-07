using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 成员权限改变的事件（该成员不是Bot）
/// </summary>
public record MemberPermissionChangeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.MemberPermissionChangeEvent;

    /// <summary>
    /// 原来的权限
    /// </summary>
    [JsonProperty("origin")]
    public GroupPermissions Origin { get; set; }

    /// <summary>
    /// 被改变后的权限
    /// </summary>
    [JsonProperty("current")]
    public GroupPermissions Current { get; set; }

    /// <summary>
    /// 权限被改变的群员信息
    /// </summary>
    [JsonProperty("group")]
    public GroupMember Member { get; set; }
}