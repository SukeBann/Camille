using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// Json文本
/// </summary>
public record Json : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; init; } = MiraiMsgType.Json;
    
    /// <summary>
    /// json文本
    /// </summary>
    [JsonProperty("json")]
    public string JsonContent { get; set; }
}