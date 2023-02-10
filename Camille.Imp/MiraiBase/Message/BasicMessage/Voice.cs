using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 语音
/// </summary>
public record Voice : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Voice;
    
    /// <summary>
    /// 语音的voiceId，不为空时将忽略url属性
    /// </summary>
    [JsonProperty("voiceId")]
    public string VoiceId { get; set; }
    
    /// <summary>
    /// 语音的URL，发送时可作网络语音的链接；接收时为腾讯语音服务器的链接，可用于语音下载
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }
    
    /// <summary>
    /// 语音的路径，发送本地语音，路径相对于 JVM 工作路径（默认是当前路径，可通过 -Duser.dir=...指定），也可传入绝对路径。
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; }
    
    /// <summary>
    /// 语音的 Base64 编码
    /// </summary>
    [JsonProperty("base64")]
    public string Base64 { get; set; }
    
    /// <summary>
    /// 返回的语音长度， 发送消息时可以不穿
    /// </summary>
    [JsonProperty("length")]
    public long Length { get; set; }
}