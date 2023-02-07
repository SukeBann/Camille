using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群头衔改动（只有群主有操作限权）
/// </summary>
public record MemberSpecialTitleChangeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.MemberSpecialTitleChangeEvent;

    /// <summary>
    /// 原来的头衔 
    /// </summary>
    [JsonProperty("origin")]
    public GroupPermissions Origin { get; set; }

    /// <summary>
    /// 改变后的头衔
    /// </summary>
    [JsonProperty("current")]
    public GroupPermissions Current { get; set; }

    /// <summary>
    /// 被改变头衔的群员信息
    /// </summary>
    [JsonProperty("member")]
    public GroupMember Member { get; set; }
}