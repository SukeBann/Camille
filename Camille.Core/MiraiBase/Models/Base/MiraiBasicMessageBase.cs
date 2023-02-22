using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Core.MiraiBase.Models.Base;

/// <summary>
/// 基础消息类型的父类
/// </summary>
public record MiraiBasicMessageBase : IMiraiBasicMessage
{
    /// <inheritdoc/>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiBasicMsgType MiraiBasicMsgType { get; init; }
}