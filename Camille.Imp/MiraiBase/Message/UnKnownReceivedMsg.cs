using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message;

/// <summary>
/// 未知接收消息
/// </summary>
public record UnKnownReceivedMsg: IMiraiMessageReceived, IMiraiUnknownData
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MiraiContainerMsgType ContainerMsgType { get; init; } = MiraiContainerMsgType.UnKnown;
    
    /// <summary>
    /// 源数据
    /// </summary>
    public string SourceData { get; init; }
}