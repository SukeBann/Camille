using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// 描述一个QQ账号的基本信息
/// </summary>
public record Account
{
    /// <summary>
    /// 好友qq号
    /// </summary>
    [JsonProperty("id")]
    public int Id { get; set; }
    
    /// <summary>
    /// 好友昵称
    /// </summary>
    [JsonProperty("nickname")]
    public string Nickname { get; set; }
    
    /// <summary>
    /// 机器人账号给好友的备注
    /// </summary>
    [JsonProperty("remark")]
    public string Remark { get; set; }
}

