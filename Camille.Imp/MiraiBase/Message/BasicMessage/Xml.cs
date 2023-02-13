using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// XML文本
/// </summary>
public record Xml : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Xml;

    /// <summary>
    /// xml文本
    /// </summary>
    [JsonProperty("xml")]
    public string XmlContent { get; set; }
}