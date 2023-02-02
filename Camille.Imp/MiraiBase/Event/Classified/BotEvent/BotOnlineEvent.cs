using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.BotEvent;

/// <summary>
/// Bot登录成功
/// </summary>
public class BotOnlineEvent: MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.BotOnlineEvent;

    [JsonProperty("qq")]
    public long QQ { get; set; }
}