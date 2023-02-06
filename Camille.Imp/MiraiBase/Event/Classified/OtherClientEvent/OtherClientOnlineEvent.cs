using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase.Models;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Event.Classified.GroupEvent;

/// <summary>
/// 其他客户端上线
/// </summary>
public class OtherClientOnlineEvent : MiraiEventBase
{
    public override MiraiEventType EventType { get; set; } = MiraiEventType.OtherClientOnlineEvent;
    
    /// <summary>
    /// 其他客户端信息
    /// </summary>
    [JsonProperty("client")]
    public MiraiClient Client { get; set; } 
    
    /// <summary>
    /// 详细设备类型
    /// </summary>
    [JsonProperty("kind")]
    public long? Kind { get; set; } 
}