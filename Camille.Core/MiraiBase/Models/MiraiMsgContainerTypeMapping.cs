using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Contract;

namespace Camille.Core.MiraiBase.Models;

/// <summary>
/// <see cref="Type"/> mapping of Mirai MsgReceived: <see cref="MiraiContainerMsgType"/>
/// </summary>
/// <param name="IdentityType">消息接收类型</param>
/// <param name="MiraiTypeName">消息接收类型string文本</param>
/// <param name="InstanceType">消息接收实例类型</param>
public record MiraiMsgContainerTypeMapping(
    MiraiContainerMsgType IdentityType,
    string MiraiTypeName,
    Type InstanceType) : IMiraiTypeMapping<MiraiContainerMsgType>;