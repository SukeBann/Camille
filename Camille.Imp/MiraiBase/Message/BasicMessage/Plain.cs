using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 文字消息
/// </summary>
public record Plain : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; set; } = MiraiMsgType.Plain;
    
    /// <summary>
    /// 文本内容
    /// </summary>
    [JsonProperty("text")]
    public string Text { get; set; }
}