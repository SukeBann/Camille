using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

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