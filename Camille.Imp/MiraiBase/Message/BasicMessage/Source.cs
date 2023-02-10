using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 消息识别源, Source类型永远为chain的第一个元素
/// </summary>
public record Source : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Source;
    
    /// <summary>
    /// 消息的识别号，用于引用回复
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// 时间戳
    /// </summary>
    [JsonProperty("time")]
    public int Time { get; set; }
}