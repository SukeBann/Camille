using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群名称发生改变
/// </summary>
public class GroupNameChangeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.GroupNameChangeEvent;

    /// <summary>
    /// 原群名称
    /// </summary>
    [JsonProperty("origin")]
    public string Origin { get; set; }

    /// <summary>
    /// 当前群名称
    /// </summary>
    [JsonProperty("current")]
    public string Current { get; set; }

    /// <summary>
    /// 群名称发生改变的群信息
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 操作者, 当为null时为bot操作
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember? Operator { get; set; }
}