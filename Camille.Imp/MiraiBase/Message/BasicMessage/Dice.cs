using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 点数
/// </summary>
public record Dice : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; set; } = MiraiMsgType.Dice;

    /// <summary>
    /// 点数
    /// </summary>
    [JsonProperty("value")]
    public int Value { get; set; }
}