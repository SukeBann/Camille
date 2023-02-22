using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// At
/// </summary>
public record At : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.At;

    /// <summary>
    /// 群员QQ号
    /// </summary>
    [JsonProperty("target")]
    public long Target { get; set; }

    /// <summary>
    /// At时显示的文字，发送消息时无效，自动使用群名片
    /// </summary>
    [JsonProperty("display")]
    public string Display { get; set; }
}