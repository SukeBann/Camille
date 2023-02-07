using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// QQ表情
/// </summary>
public record Face : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; init; } = MiraiMsgType.Face;
    
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