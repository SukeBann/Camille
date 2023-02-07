using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.MessageReceived;

/// <summary>
/// 接收到的群消息
/// </summary>
public record GroupMessageReceived: MessageReceivedBase
{
    public override MiraiReceiveMsgType ReceiveMsgType { get; init; } = MiraiReceiveMsgType.GroupMessage;
    
    /// <summary>
    /// 消息的发送者
    /// </summary>
    [JsonProperty("sender")]
    public GroupMember Sender { get; set; }
}