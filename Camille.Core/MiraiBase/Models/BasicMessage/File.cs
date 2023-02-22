using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// 文件
/// </summary>
public record File : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.File;

    /// <summary>
    /// 文件识别Id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// 文件名
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// 文件大小
    /// </summary>
    [JsonProperty("size")]
    public long Size { get; set; }
}