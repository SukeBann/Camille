using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 全员禁言
/// </summary>
public record GroupMuteAllEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.GroupMuteAllEvent;

    /// <summary>
    /// 原本全员禁言状态是否开启
    /// </summary>
    [JsonProperty("origin")]
    public bool Origin { get; set; }

    /// <summary>
    /// 现在全员禁言状态是否开启
    /// </summary>
    [JsonProperty("current")]
    public bool Current { get; set; }

    /// <summary>
    /// 全员禁言状态发生改变的群信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 操作者, 当为null时为bot操作
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember? Operator { get; set; }
}