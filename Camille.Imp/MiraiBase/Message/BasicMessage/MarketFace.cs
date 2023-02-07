using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 商城表情
/// </summary>
public record MarketFace : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; set; } = MiraiMsgType.MarketFace;

    /// <summary>
    /// 商场表情唯一标识
    /// </summary>
    [JsonProperty("id")] public int Id { get; set; }

    /// <summary>
    /// 表情显示名称
    /// </summary>
    [JsonProperty("name")] public int Name { get; set; }
}