using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// Bot被接触禁言
/// </summary>
public record BotUnmuteEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; init; } = MiraiEventType.BotUnmuteEvent;

    /// <summary>
    /// 产生该事件的操作者, 绝对是管理员或者群主
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember Operator { get; set; }
}