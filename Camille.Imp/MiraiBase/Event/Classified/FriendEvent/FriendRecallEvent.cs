using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.FriendEvent;

/// <summary>
/// 好友会话中的消息被撤回
/// </summary>
public record FriendRecallEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.FriendRecallEvent;

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
    /// 好友QQ号或BotQQ号（谁撤回就是谁的）
    /// </summary>
    [JsonProperty("authorId")]
    public long Operator { get; set; }
}