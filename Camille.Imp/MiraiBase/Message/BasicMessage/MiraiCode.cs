using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// MiraiCode
/// </summary>
public record MiraiCode : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.MiraiCode;

    /// <summary>
    /// MiraiCode
    /// </summary>
    [JsonProperty("code")]
    public string Code { get; set; }
}