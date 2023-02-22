using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 未知接收消息
/// </summary>
public record UnKnownContainerMsg : IMiraiMessageContainer, IMiraiUnknownData
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.UnKnown;

    /// <summary>
    /// 源数据
    /// </summary>
    public string SourceData { get; init; }
}