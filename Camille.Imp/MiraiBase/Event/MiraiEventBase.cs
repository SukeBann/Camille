using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Event;

/// <summary>
/// Mirai事件基类
/// </summary>
public class MiraiEventBase : IMiraiEvent
{
    /// <inheritdoc/>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiEventType EventType { get; set; }
}