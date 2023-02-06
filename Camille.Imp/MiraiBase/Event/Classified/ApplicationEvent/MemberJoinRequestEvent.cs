using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.ApplicationEvent;

/// <summary>
///  用户入群申请（Bot需要有管理员权限才会收到）
/// </summary>
public record MemberJoinRequestEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.MemberJoinRequestEvent;

    /// <summary>
    /// 事件标识, 响应该事件时的标识
    /// </summary>
    [JsonProperty("eventId")]
    public long EventId { get; set; }

    /// <summary>
    /// 申请人的qq号
    /// </summary>
    [JsonProperty("fromId")]
    public long FromId { get; set; }

    /// <summary>
    /// 申请人的昵称或群名片
    /// </summary>
    [JsonProperty("nick")]
    public long Nick { get; set; }

    /// <summary>
    /// 申请人申请入群的群号
    /// </summary>
    [JsonProperty("groupId")]
    public long GroupId { get; set; }

    /// <summary>
    /// 被邀请进入的群名称
    /// </summary>
    [JsonProperty("groupName")]
    public long GroupName { get; set; }

    /// <summary>
    /// 申请信息
    /// </summary>
    [JsonProperty("message")]
    public long Message { get; set; }
}