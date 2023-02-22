using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

public record GroupRecallEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.GroupRecallEvent;

    /// <summary>
    /// 原消息发送者的QQ号 
    /// </summary>
    [JsonProperty("authorId")]
    public long AuthorId { get; set; }

    /// <summary>
    /// 消息id
    /// </summary>
    [JsonProperty("messageId")]
    public int MessageId { get; set; }

    /// <summary>
    /// 原消息发送时间戳
    /// </summary>
    [JsonProperty("time")]
    public int Time { get; set; }

    /// <summary>
    /// 消息撤回所在的群
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 撤回消息的操作者, 为null则为bot的操作
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember Operator { get; set; }
}