using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Contract;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Imp.MiraiBase.Tools.JsonConverter;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message;

/// <summary>
/// 收到的消息的基类
/// </summary>
public record MiraiMsgContainerBase : IMiraiMessageContainer
{
    /// <summary>
    /// 收到的消息类型
    /// </summary>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiContainerMsgType ContainerMsgType { get; init; }

    /// <summary>
    /// 消息链内容体
    /// </summary>
    [JsonProperty("messageChain")]
    [JsonConverter(typeof(MiraiMessageChainConverter))]
    public MessageChain MessageChain { get; set; }
    
    /// <summary>
    /// 消息发送者
    /// </summary>
    [JsonProperty("sender")]
    public virtual Account? Sender { get; set; }
}