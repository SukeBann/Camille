using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Core.MiraiBase.Models;

/// <summary>
/// 创建<see cref="GroupMember"/>的实例
/// </summary>
public class GroupMember
{
    /// <summary>
    /// 群员的QQ号
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; init; }

    /// <summary>
    /// 群员的群昵称
    /// </summary>
    [JsonProperty("memberName")]
    public string MemberName { get; init; }

    /// <summary>
    /// 群成员在群中的权限
    /// </summary>
    [JsonProperty("permission")]
    [JsonConverter(typeof(StringEnumConverter))]
    public GroupPermissions MemberPermission { get; init; }

    /// <summary>
    /// 群成员的群头衔
    /// </summary>
    [JsonProperty("specialTitle")]
    public string SpecialTitle { get; init; }

    /// <summary>
    /// 当前群成员加入群聊的时间戳
    /// </summary>
    [JsonProperty("joinTimestamp")]
    public string JoinTimestamp { get; init; }

    /// <summary>
    /// 当前群成员最后发言时间戳
    /// </summary>
    [JsonProperty("lastSpeakTimestamp")]
    public string LastSpeakTimestamp { get; init; }

    /// <summary>
    /// 当前群成员剩余禁言时间
    /// </summary>
    [JsonProperty("muteTimeRemaining")]
    public string MuteTimeRemaining { get; init; }

    /// <summary>
    /// 当前群成员事件发生所在的群
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; init; }
}