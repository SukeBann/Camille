using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// 其他QQ客户端
/// </summary>
public record MiraiClient
{
    public MiraiClient(long id, string platform)
    {
        Id = id;
        Platform = platform;
    }

    /// <summary>
    /// 客户端标识
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; init; }
    
    /// <summary>
    /// 客户端平台类型
    /// </summary>
    [JsonProperty("platform")]
    public string Platform { get; init; }
    
}