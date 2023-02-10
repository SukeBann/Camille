using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Event;

/// <summary>
/// 未知事件
/// </summary>
public record UnKnownEvent: IMiraiEvent, IMiraiUnknownData
{
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MiraiEventType EventType { get; init; } = MiraiEventType.UnKnown;

    /// <summary>
    /// 源数据
    /// </summary>
    public string SourceData { get; init; }
}