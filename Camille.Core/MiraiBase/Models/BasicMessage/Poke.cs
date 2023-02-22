using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// 戳一戳
/// </summary>
public record Poke : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Poke;

    /// <summary>
    /// 戳一戳的类型
    /// </summary>
    [JsonProperty("name")]
    public MiraiPokeType PokeType { get; set; }
}