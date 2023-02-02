using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// Bot在群里的权限被改变. 操作人一定是群主
/// </summary>
public class BotGroupPermissionChangeEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotGroupPermissionChangeEvent;

    /// <summary>
    /// Bot在群中原来的权限
    /// </summary>
    [JsonProperty("origin")]
    public GroupPermissions Origin { get; set; }

    /// <summary>
    /// Bot在群中的当前权限
    /// </summary>
    [JsonProperty("current")]
    public GroupPermissions Current { get; set; }

    /// <summary>
    /// 群信息
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }
}