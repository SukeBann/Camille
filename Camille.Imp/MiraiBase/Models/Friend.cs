using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Models;

/// <summary>
/// 好友数据
/// </summary>
public record Friend
{
    public Friend(int id, string nickname, string remark)
    {
        Id = id;
        Nickname = nickname;
        Remark = remark;
    }

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

