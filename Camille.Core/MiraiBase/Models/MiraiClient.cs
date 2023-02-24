using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models;

/// <summary>
/// 其他QQ客户端
/// </summary>
public record MiraiClient(long Id, string Platform)
{
    /// <summary>
    /// 客户端标识
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; init; } = Id;

    /// <summary>
    /// 客户端平台类型
    /// </summary>
    [JsonProperty("platform")]
    public string Platform { get; init; } = Platform;
}