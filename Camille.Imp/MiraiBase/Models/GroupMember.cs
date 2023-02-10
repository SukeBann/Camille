using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// 创建<see cref="GroupMember"/>的实例
/// </summary>
/// <param name="Id">群友QQ</param>
/// <param name="MemberName">群员的群名片</param>
/// <param name="MemberPermission">群中的权限</param>
/// <param name="SpecialTitle">群头衔</param>
/// <param name="JoinTimestamp">加入时间戳</param>
/// <param name="LastSpeakTimestamp">最后发言时间戳</param>
/// <param name="MuteTimeRemaining">剩余禁言时间</param>
/// <param name="Group">群信息</param>
public record GroupMember(string Id,
    string MemberName,
    GroupPermissions MemberPermission,
    string SpecialTitle,
    string JoinTimestamp,
    string LastSpeakTimestamp,
    string MuteTimeRemaining,
    Group Group)
{
    
    /// <summary>
    /// 群员的QQ号
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; init; } = Id;

    /// <summary>
    /// 群员的群昵称
    /// </summary>
    [JsonProperty("memberName")]
    public string MemberName { get; init; } = MemberName;

    /// <summary>
    /// 群成员在群中的权限
    /// </summary>
    [JsonProperty("permission")]
    [JsonConverter(typeof(StringEnumConverter))]
    public GroupPermissions MemberPermission { get; init; } = MemberPermission;

    /// <summary>
    /// 群成员的群头衔
    /// </summary>
    [JsonProperty("specialTitle")]
    public string SpecialTitle { get; init; } = SpecialTitle;

    /// <summary>
    /// 当前群成员加入群聊的时间戳
    /// </summary>
    [JsonProperty("joinTimestamp")]
    public string JoinTimestamp { get; init; } = JoinTimestamp;

    /// <summary>
    /// 当前群成员最后发言时间戳
    /// </summary>
    [JsonProperty("lastSpeakTimestamp")]
    public string LastSpeakTimestamp { get; init; } = LastSpeakTimestamp;

    /// <summary>
    /// 当前群成员剩余禁言时间
    /// </summary>
    [JsonProperty("muteTimeRemaining")]
    public string MuteTimeRemaining { get; init; } = MuteTimeRemaining;

    /// <summary>
    /// 当前群成员事件发生所在的群
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; init; } = Group;
}