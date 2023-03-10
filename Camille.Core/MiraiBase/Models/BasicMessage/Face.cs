using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// QQ表情
/// </summary>
public record Face : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Face;

    /// <summary>
    /// QQ表情编号，可选，优先高于name
    /// </summary>
    [JsonProperty("faceId")]
    public int FaceId { get; set; }

    /// <summary>
    /// QQ表情拼音，可选
    /// </summary>
    [JsonProperty("name")]
    public string FaceName { get; set; }
}