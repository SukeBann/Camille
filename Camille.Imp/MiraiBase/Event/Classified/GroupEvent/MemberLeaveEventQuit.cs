using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 成员主动离群（该成员不是Bot）
/// </summary>
public class MemberLeaveEventQuit : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.MemberLeaveEventQuit;

    /// <summary>
    /// 离开群聊的群员信息
    /// </summary>
    [JsonProperty("group")]
    public GroupMember Member { get; set; }
}