using System.Security.Principal;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.FriendEvent;

/// <summary>
/// 好友输入状态变更
/// </summary>
public record FriendInputStatusChangedEvent : MiraiEventBase
{
    public FriendInputStatusChangedEvent(Account friend)
    {
        Friend = friend;
    }

    public override MiraiEventType EventType { get; init; } = MiraiEventType.FriendInputStatusChangedEvent;

    /// <summary>
    /// 当前好友是否正在输入
    /// </summary>
    [JsonProperty("inputting")]
    public bool Inputting { get; set; }

    /// <summary>
    /// 好友信息
    /// </summary>
    [JsonProperty("friend")]
    public Account Friend { get; set; }
}