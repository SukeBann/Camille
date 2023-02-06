using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Models;

public record GroupMember
{
    /// <summary>
    /// 群员的QQ号
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// 群员的群昵称
    /// </summary>
    [JsonProperty("memberName")]
    public string MemberName { get; set; }

    /// <summary>
    /// 群成员在群中的权限
    /// </summary>
    [JsonProperty("permission")]
    [JsonConverter(typeof(StringEnumConverter))]
    public GroupPermissions MemberPermission { get; set; }

    /// <summary>
    /// 群成员的群头衔
    /// </summary>
    [JsonProperty("specialTitle")]
    public string SpecialTitle { get; set; }

    /// <summary>
    /// 当前群成员加入群聊的时间戳
    /// </summary>
    [JsonProperty("joinTimestamp")]
    public string JoinTimestamp { get; set; }

    /// <summary>
    /// 当前群成员最后发言时间戳
    /// </summary>
    [JsonProperty("lastSpeakTimestamp")]
    public string LastSpeakTimestamp { get; set; }

    /// <summary>
    /// 当前群成员剩余禁言时间
    /// </summary>
    [JsonProperty("muteTimeRemaining")]
    public string MuteTimeRemaining { get; set; }

    /// <summary>
    /// 当前群成员事件发生所在的群
    /// </summary>
    [JsonProperty("group")]
    public Group Group { get; set; }}