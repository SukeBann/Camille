using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// 合并转发消息
/// </summary>
[Obsolete("NotImplement!!!!")]
// TODO 记得实现这个类型
public record ForwardMessage : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.ForwardMessage;
}