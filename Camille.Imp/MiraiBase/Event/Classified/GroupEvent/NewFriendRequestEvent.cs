using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

public class NewFriendRequestEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.NewFriendRequestEvent;
}