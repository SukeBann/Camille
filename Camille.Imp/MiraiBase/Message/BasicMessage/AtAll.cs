using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// AtAll @全员
/// </summary>
public record AtAll : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.AtAll;
}