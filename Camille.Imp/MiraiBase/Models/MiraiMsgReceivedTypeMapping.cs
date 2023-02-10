using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models.Contract;

namespace Camille.Imp.MiraiBase.Models;

public record MiraiMsgReceivedTypeMapping: IMiraiTypeMapping<MiraiReceiveMsgType>
{
    public MiraiReceiveMsgType IdentityType { get; init; }
    public string MiraiTypeName { get; init; }
    public Type InstanceType { get; init; }
}