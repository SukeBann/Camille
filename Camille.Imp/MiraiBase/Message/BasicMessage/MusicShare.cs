using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;

namespace Camille.Imp.MiraiBase.Message.BasicMessage;

/// <summary>
/// 音乐分享
/// </summary>
public record MusicShare : BasicMessageBase
{
    public override MiraiMsgType MiraiMsgType { get; set; } = MiraiMsgType.MusicShare;

    /// <summary>
    ///  类型
    /// </summary>
    [JsonProperty("kind")]
    public string Kind { get; set; }

    /// <summary>
    ///  标题
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }

    /// <summary>
    /// 概括
    /// </summary>
    [JsonProperty("summary")]
    public string Summary { get; set; }

    /// <summary>
    /// 跳转路径
    /// </summary>
    [JsonProperty("jumpUrl")]
    public string JumpUrl { get; set; }

    /// <summary>
    /// 封面路径
    /// </summary>
    [JsonProperty("pictureUrl")]
    public string PictureUrl { get; set; }

    /// <summary>
    /// 音源路径
    /// </summary>
    [JsonProperty("musicUrl")]
    public string MusicUrl { get; set; }

    /// <summary>
    /// 简介
    /// </summary>
    [JsonProperty("brief")]
    public string Brief { get; set; }
}