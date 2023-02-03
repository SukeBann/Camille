using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

public class MemberLeaveEventKick : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.MemberLeaveEventKick;
}