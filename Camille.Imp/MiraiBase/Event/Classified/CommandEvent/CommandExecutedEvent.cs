using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.CommandEvent;

/// <summary>
/// 命令被执行事件
/// </summary>
public class CommandExecutedEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.CommandExecutedEvent;
    
    /// <summary>
    /// 事件标识, 响应该事件时的标识
    /// </summary>
    [JsonProperty("eventId")]
    public long EventId { get; set; }
    
    [JsonProperty("name")]
    public string Name { get; set; }
    
    [JsonProperty("friend")]
    public Friend Friend { get; set; }
    
    [JsonProperty("member")]
    public GroupMember Member { get; set; } 
    
    /// <summary>
    /// NotImplement
    /// </summary>
    [JsonProperty("args")]
    public dynamic Args { get; set; } 
}