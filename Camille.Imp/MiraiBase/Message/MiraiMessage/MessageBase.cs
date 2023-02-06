using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message.MiraiMessage;

/// <summary>
/// 消息类型基础类
/// </summary>
public class MessageBase: IMiraiMessage
{
    /// <inheritdoc/>
    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public virtual MiraiMsgType MiraiMsgType { get; set; }

}