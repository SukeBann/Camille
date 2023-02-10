using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// 群信息
/// </summary>
public record Group(string Id, string Name, GroupPermissions BotPermission)
{
    /// <summary>
    /// 群号
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; init; } = Id;

    /// <summary>
    /// 群名称
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; init; } = Name;

    /// <summary>
    /// Bot在群中的权限
    /// </summary>
    [JsonProperty("permission")]
    [JsonConverter(typeof(StringEnumConverter))]
    public GroupPermissions BotPermission { get; init; } = BotPermission;
}