using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.ApplicationEvent;

/// <summary>
/// 添加好友申请
/// </summary>
public record NewFriendRequestEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.NewFriendRequestEvent;

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
    /// 邀请人(好友)的昵称
    /// </summary>
    [JsonProperty("nick")]
    public long Nick { get; set; }

    /// <summary>
    /// 申请人如果通过某个群添加好友，该项为该群群号；否则为0
    /// </summary>
    [JsonProperty("groupId")]
    public long GroupId { get; set; }

    /// <summary>
    /// 是否为群内成员发送的申请 
    /// </summary>
    [JsonIgnore]
    public bool ApplicationIsFromGroup { get; set; }

    /// <summary>
    /// 邀请信息
    /// </summary>
    [JsonProperty("message")]
    public long Message { get; set; }
}