using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

/// <summary>
/// 接收到的临时消息
/// </summary>
public record TempMiraiMsgContainer : MiraiMsgContainerBase
{
    public override MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.TempMessage;

    /// <summary>
    /// 消息的发送者
    /// </summary>
    [JsonProperty("sender")]
    public GroupMember Sender { get; set; }
}