using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.CommonApi;

/// <summary>
/// 会话信息
/// </summary>
/// <param name="SessionKey">会话秘钥</param>
/// <param name="QQ">qq账户</param>
public record SessionInfo(string SessionKey, Account QQ)
{
    [JsonProperty("sessionKey")]
    public string SessionKey { get; set; } = SessionKey;

    [JsonProperty("qq")]
    public Account QQ { get; set; } = QQ;
}