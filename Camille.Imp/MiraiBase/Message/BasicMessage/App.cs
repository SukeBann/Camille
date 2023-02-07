using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 内容(小程序消息?) 文档也看不到这个到底是什么消息
/// </summary>
public record App : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; set; } = MiraiMsgType.App;

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }
}