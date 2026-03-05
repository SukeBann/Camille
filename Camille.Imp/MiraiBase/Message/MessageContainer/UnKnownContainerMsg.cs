using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Contract;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message.MessageContainer;

/// <summary>
/// 未知接收消息
/// </summary>
public record UnKnownContainerMsg : MiraiMsgContainerBase, IMiraiUnknownData
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.UnKnown;

    /// <inheritdoc />
    public MessageChain? MessageChain { get; set; }

    /// <inheritdoc />
    public override Account? Sender { get; set; }

    /// <summary>
    /// 源数据
    /// </summary>
    public string SourceData { get; init; }
}