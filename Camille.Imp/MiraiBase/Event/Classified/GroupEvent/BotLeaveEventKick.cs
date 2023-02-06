using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// Bot被踢出群聊
/// </summary>
public record BotLeaveEventKick : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotLeaveEventKick;

    /// <summary>
    /// Bot被踢出的群信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }

    /// <summary>
    /// 产生该事件的操作者, 绝对是群主或管理员
    /// </summary>
    [JsonProperty("operator")]
    public GroupMember Operator { get; set; }
}