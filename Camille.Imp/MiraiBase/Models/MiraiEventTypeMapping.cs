using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models.Contract;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// <see cref="Type"/> mapping of Mirai Event<see cref="MiraiEventType"/>
/// </summary>
/// <param name="IdentityType">事件类型</param>
/// <param name="MiraiTypeName">事件类型string文本</param>
/// <param name="InstanceType">事件实例类型</param>
public record MiraiEventTypeMapping(MiraiEventType IdentityType, string MiraiTypeName, Type InstanceType) : IMiraiTypeMapping<MiraiEventType>;