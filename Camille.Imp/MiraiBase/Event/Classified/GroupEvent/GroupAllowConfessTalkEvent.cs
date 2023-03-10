using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 群坦白说状态发生改变
/// </summary>
public record GroupAllowConfessTalkEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.GroupAllowConfessTalkEvent;

    /// <summary>
    /// 原本坦白说状态是否开启
    /// </summary>
    [JsonProperty("origin")]
    public bool Origin { get; set; }

    /// <summary>
    /// 当前坦白说状态是否开启
    /// </summary>
    [JsonProperty("current")]
    public bool Current { get; set; }

    /// <summary>
    /// 坦白说发生改变的群信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 是否Bot进行操作 
    /// </summary>
    [JsonProperty("isByBot")]
    public bool IsByBot { get; set; }
}