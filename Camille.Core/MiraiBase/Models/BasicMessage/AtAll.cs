using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// AtAll @全员
/// </summary>
public record AtAll : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.AtAll;
}