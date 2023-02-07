using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message;

/// <summary>
/// 收到的消息的基类
/// </summary>
public record MessageReceivedBase: IMiraiMessageReceived
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiReceiveMsgType ReceiveMsgType { get; set; }
    
    /// <summary>
    /// 消息链内容体
    /// </summary>
    [JsonProperty("messageChain")]
    public MessageChain MessageChain { get; set; }
}