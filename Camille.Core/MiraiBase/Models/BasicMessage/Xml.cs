using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

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