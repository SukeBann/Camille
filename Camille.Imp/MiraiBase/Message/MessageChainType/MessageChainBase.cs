using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message.MessageChainType;

/// <summary>
/// 消息链基础类
/// </summary>
public class MessageChainBase: IMiraiMessageChain
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiMsgChainType MsgChainType { get; set; }
    
    /// <summary>
    /// 消息链内容体
    /// </summary>
    [JsonProperty("messageChain")]
    public MessageChain MessageChain { get; set; }
}