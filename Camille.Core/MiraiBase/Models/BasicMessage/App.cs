using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// 内容(小程序消息?) 文档也看不到这个到底是什么消息
/// </summary>
public record App : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.App;

    /// <summary>
    /// 消息内容
    /// </summary>
    [JsonProperty("content")]
    public string Content { get; set; }
}