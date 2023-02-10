using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models.Contract;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// Mirai的消息类型映射<see cref="MiraiEventType"/>
/// </summary>
public record MiraiBasicMsgTypeMapping(
    MiraiBasicMsgType IdentityType,
    string MiraiTypeName,
    Type InstanceType) : IMiraiTypeMapping<MiraiBasicMsgType>;