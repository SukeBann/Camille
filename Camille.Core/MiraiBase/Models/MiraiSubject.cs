using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models;

/// <summary>
/// 事件或信息的来源
/// </summary>
public record MiraiSubject(long Id, MiraiSubjectType Kind)
{
    /// <summary>
    /// 来源的qq号或者群号
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; init; } = Id;

    /// <summary>
    /// 来源的类型 <see cref="MiraiSubjectType"/>
    /// </summary>
    [JsonProperty("kind")]
    public MiraiSubjectType Kind { get; init; } = Kind;
}