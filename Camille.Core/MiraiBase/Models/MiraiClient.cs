using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models;

/// <summary>
/// 其他QQ客户端
/// </summary>
public record MiraiClient : Account
{
    public MiraiClient(long Id, string Platform)
    {
        this.Id = Id;
        this.Platform = Platform;
    }

    /// <summary>
    /// 客户端平台类型
    /// </summary>
    [JsonProperty("platform")]
    public string Platform { get; init; }
}