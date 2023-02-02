using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.FriendEvent;

/// <summary>
/// 好友昵称改变
/// </summary>
public class FriendNickChangedEvent : MiraiEventBase
{
    public FriendNickChangedEvent(Friend friend, string from, string to)
    {
        Friend = friend;
        From = from;
        To = to;
    }

    /// <summary>
    /// 事件类型
    /// </summary>
    public override MiraiEventType EventType { get; set; } = MiraiEventType.FriendNickChangedEvent;   

    /// <summary>
    ///     发出此事件的好友
    /// </summary>
    [JsonProperty("friend")]
    public Friend Friend { get; set; }

    /// <summary>
    /// 改变前的昵称
    /// </summary>
    [JsonProperty("from")]
    public string From { get; set; }

    /// <summary>
    /// 新昵称
    /// </summary>
    [JsonProperty("to")]
    public string To { get; set; }
}