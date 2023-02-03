using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Event.Classified.CommandEvent;

public class CommandExecutedEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.CommandExecutedEvent;
}