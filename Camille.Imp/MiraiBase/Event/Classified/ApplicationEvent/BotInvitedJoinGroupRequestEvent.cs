using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.ApplicationEvent;

/// <summary>
/// Bot被邀请入群申请
/// </summary>
public record BotInvitedJoinGroupRequestEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotInvitedJoinGroupRequestEvent;

    /// <summary>
    /// 事件标识, 响应该事件时的标识
    /// </summary>
    [JsonProperty("eventId")]
    public long EventId { get; set; }

    /// <summary>
    /// 邀请人(好友)的qq号
    /// </summary>
    [JsonProperty("fromId")]
    public long FromId { get; set; }

    /// <summary>
    /// 邀请人(好友)的昵称
    /// </summary>
    [JsonProperty("nick")]
    public long Nick { get; set; }

    /// <summary>
    /// 被邀请进入的群号
    /// </summary>
    [JsonProperty("groupId")]
    public long GroupId { get; set; }

    /// <summary>
    /// 被邀请进入的群名称
    /// </summary>
    [JsonProperty("groupName")]
    public long GroupName { get; set; }

    /// <summary>
    /// 邀请信息
    /// </summary>
    [JsonProperty("message")]
    public long Message { get; set; }
}