using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群员称号改变
/// </summary>
public record MemberHonorChangeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.MemberHonorChangeEvent;

    /// <summary>
    /// 群称号改动的群员的信息
    /// </summary>
    [JsonProperty("member")]
    public GroupMember Member { get; set; }

    /// <summary>
    /// 称号变化行为：Achieve获得称号，Lose失去称号
    /// </summary>
    [JsonProperty("action")]
    public MemberHonorChangeType ChangeType { get; set; }

    /// <summary>
    /// 群称号名称
    /// </summary>
    [JsonProperty("honor")]
    public string Honor { get; set; }
}