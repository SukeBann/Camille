using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
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
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiContainerMsgType ContainerMsgType { get; init; }

    /// <summary>
    /// 消息链内容体
    /// </summary>
    [JsonProperty("messageChain")]
    [JsonConverter(typeof(MiraiMessageChainConverter))]
    public MessageChain MessageChain { get; set; }
}