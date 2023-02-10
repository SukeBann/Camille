using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models.Contract;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// Mirai的事件类型映射<see cref="MiraiEventType"/>
/// </summary>
public record MiraiEventTypeMapping : IMiraiTypeMapping<MiraiEventType>
{
    public MiraiEventType IdentityType { get; init; }

    public string MiraiTypeName { get; init; }

    public Type InstanceType { get; init; }
}