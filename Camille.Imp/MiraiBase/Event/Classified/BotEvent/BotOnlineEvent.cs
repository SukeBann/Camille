using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.BotEvent;

/// <summary>
/// Bot登录成功
/// </summary>
public class BotOnlineEvent: MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotOnlineEvent;

    /// <summary>
    /// bot的qq
    /// </summary>
    [JsonProperty("qq")]
    public long QQ { get; set; }
}