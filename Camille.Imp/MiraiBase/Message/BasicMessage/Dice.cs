using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 点数
/// </summary>
public record Dice : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Dice;

    /// <summary>
    /// 点数
    /// </summary>
    [JsonProperty("value")]
    public int Value { get; set; }
}