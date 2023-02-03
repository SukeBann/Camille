using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Event.Classified.ApplicationEvent;

/// <summary>
/// Bot被邀请入群申请
/// </summary>
public class BotInvitedJoinGroupRequestEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotInvitedJoinGroupRequestEvent;
    
}