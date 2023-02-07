using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// AtAll @全员
/// </summary>
public record AtAll : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; set; } = MiraiMsgType.AtAll;
}