using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageReceived;

public record StrangerSyncMessageReceived : MiraiMsgReceivedBase
{
    public override MiraiReceiveMsgType ReceiveMsgType { get; init; } = MiraiReceiveMsgType.StrangerSyncMessage;
    
    /// <summary>
    /// 发送消息的陌生人账号
    /// </summary>
    [JsonProperty("subject")]
    public Account Subject { get; set; }
}