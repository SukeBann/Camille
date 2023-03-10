using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// 引用
/// </summary>
public record Quote : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Quote;

    /// <summary>
    /// 被引用回复的原消息的messageId
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }

    /// <summary>
    /// 被引用回复的原消息所接收的群号，当为好友消息时为0
    /// </summary>
    [JsonProperty("groupId")]
    public long GroupId { get; set; }

    /// <summary>
    /// 被引用回复的原消息的发送者的QQ号
    /// </summary>
    [JsonProperty("senderId")]
    public long SenderId { get; set; }

    /// <summary>
    /// 被引用回复的原消息的接收者者的QQ号（或群号）
    /// </summary>
    [JsonProperty("targetId")]
    public long TargetId { get; set; }

    /// <summary>
    /// 被引用回复的原消息的消息链对象
    /// </summary>
    [JsonProperty("origin")]
    public MessageChain Origin { get; set; }
}