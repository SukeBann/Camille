using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// MiraiCode
/// </summary>
public record MiraiCode : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; set; } = MiraiMsgType.MiraiCode;
    
    /// <summary>
    /// MiraiCode
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }
}