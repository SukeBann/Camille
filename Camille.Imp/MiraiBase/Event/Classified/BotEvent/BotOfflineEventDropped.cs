using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.BotEvent;

/// <summary>
/// Bot被服务器断开或因网络问题而掉线
/// </summary>
public class BotOfflineEventDropped: MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotOfflineEventDropped;

    /// <summary>
    /// bot的qq
    /// </summary>
    [JsonProperty("qq")]
    public long QQ { get; set; }
}