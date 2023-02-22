using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// Json文本
/// </summary>
public record Json : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Json;

    /// <summary>
    /// json文本
    /// </summary>
    [JsonProperty("json")]
    public string JsonContent { get; set; }
}