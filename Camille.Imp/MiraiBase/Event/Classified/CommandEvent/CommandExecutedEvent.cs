using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.CommandEvent;

/// <summary>
/// 命令被执行事件
/// </summary>
[Obsolete("NotImplement!!")]
public record CommandExecutedEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.CommandExecutedEvent;

    /// <summary>
    /// 事件标识, 响应该事件时的标识
    /// </summary>
    [JsonProperty("eventId")]
    public long EventId { get; set; }

    /// <summary>
    /// 命令名称
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 发送命令的好友
    /// </summary>
    [JsonProperty("friend")]
    public Friend Friend { get; set; }

    /// <summary>
    /// 发送命令的群成员
    /// </summary>
    [JsonProperty("member")]
    public GroupMember Member { get; set; }

    /// <summary>
    /// NotImplement!!
    /// 指令的参数, 以消息类型传递
    /// </summary>
    [JsonProperty("args")]
    public dynamic Args { get; set; }
}