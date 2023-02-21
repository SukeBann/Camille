using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// Bot加入了一个群
/// </summary>
public record BotJoinGroupEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.BotJoinGroupEvent;

    /// <summary>
    /// 加入的群的信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 如果是被邀请入群的, 则为邀请人的信息, 否则为null
    /// </summary>
    [JsonProperty("invitor")]
    public GroupMember? Invitor { get; set; }
}