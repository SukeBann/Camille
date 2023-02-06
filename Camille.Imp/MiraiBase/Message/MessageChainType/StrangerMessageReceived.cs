using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageChainType;

public record StrangerMessageReceived: MessageReceivedBase
{
    public override MiraiReceiveMsgType ReceiveMsgType { get; set; } = MiraiReceiveMsgType.StrangerMessage;
    
    /// <summary>
    /// 消息发送者
    /// </summary>
    [JsonProperty("sender")]
    public Friend Sender { get; set; }
}