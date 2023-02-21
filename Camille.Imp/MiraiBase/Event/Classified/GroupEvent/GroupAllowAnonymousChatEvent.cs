using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群匿名聊天状态改变
/// </summary>
public record GroupAllowAnonymousChatEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.GroupAllowAnonymousChatEvent;

    /// <summary>
    /// 原本匿名状态是否开启
    /// </summary>
    [JsonProperty("origin")]
    public bool Origin { get; set; }

    /// <summary>
    /// 现在匿名状态是否开启
    /// </summary>
    [JsonProperty("current")]
    public bool Current { get; set; }

    /// <summary>
    /// 匿名状态发生改变的群信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 操作者, 当为null时为bot操作
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember? Operator { get; set; }
}