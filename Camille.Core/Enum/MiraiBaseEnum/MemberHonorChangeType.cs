using System.ComponentModel;
using Newtonsoft.Json;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// 群称号改变事件
/// </summary>
public enum MemberHonorChangeType
{
    [Description("获得群称号")]
    [JsonProperty("achieve")]
    Achieve,
    
    [Description("失去群称号")]
    [JsonProperty("lose")]
    Lose
}