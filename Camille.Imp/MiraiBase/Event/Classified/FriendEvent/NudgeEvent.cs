using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Event.Classified.FriendEvent;

public class NudgeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.NudgeEvent;
}