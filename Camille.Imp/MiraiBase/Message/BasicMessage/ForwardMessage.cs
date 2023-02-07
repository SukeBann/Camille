using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 合并转发消息
/// </summary>
[Obsolete("NotImplement!!!!")]
// TODO 记得实现这个类型
public record ForwardMessage : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; init; } = MiraiMsgType.ForwardMessage;
}