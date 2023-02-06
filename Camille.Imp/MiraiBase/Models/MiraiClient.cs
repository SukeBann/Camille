using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// 其他QQ客户端
/// </summary>
public class MiraiClient
{
    /// <summary>
    /// 客户端标识
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }
    
    /// <summary>
    /// 客户端平台类型
    /// </summary>
    [JsonProperty("platform")]
    public string Platform { get; set; }
    
}