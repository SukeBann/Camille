using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 某群入群公告改变
/// </summary>
public class GroupEntranceAnnouncementChangeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.GroupEntranceAnnouncementChangeEvent;
    
    /// <summary>
    /// 原公告
    /// </summary>
    [JsonProperty("origin")]
    public string Origin { get; set; }
    
    /// <summary>
    /// 新公告
    /// </summary>
    [JsonProperty("current")]
    public string Current { get; set; }

    /// <summary>
    /// 入群公告发生改变的群信息
    [JsonProperty("group")]
    public Group Group { get; set; }
    
    /// <summary>
    /// 操作者, 当为null时为bot操作
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember? Operator { get; set; }
}