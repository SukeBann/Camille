using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群名片改动
/// </summary>
public record MemberCardChangeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.MemberCardChangeEvent;

    /// <summary>
    /// 原群名片
    /// </summary>
    [JsonProperty("origin")]
    public string Origin { get; set; }

    /// <summary>
    /// 当前群名片
    /// </summary>
    [JsonProperty("current")]
    public string Current { get; set; }

    /// <summary>
    /// 名片改动的群员的信息
    /// </summary>
    [JsonProperty("member")]
    public GroupMember Member { get; set; }
}