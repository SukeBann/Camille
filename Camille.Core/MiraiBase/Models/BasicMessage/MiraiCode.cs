using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

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