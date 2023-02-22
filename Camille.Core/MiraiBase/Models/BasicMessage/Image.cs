using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// 图片
/// 四个参数任选其一，出现多个参数时，按照imageId > url > path > base64的优先级
/// </summary>
public record Image : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Image;

    /// <summary>
    /// 图片的imageId，群图片与好友图片格式不同。不为空时将忽略url属性
    /// <br/> Example:
    /// <br/> 群图片格式: "{01E9451B-70ED-EAE3-B37C-101F1EEBF5B5}.mirai"
    /// <br/> 好友图片格式: "/f8f1ab55-bf8e-4236-b55e-955848d7069f"
    /// </summary>
    [JsonProperty("imageId")]
    public string ImageId { get; set; }

    /// <summary>
    /// 图片的URL，发送时可作网络图片的链接；接收时为腾讯图片服务器的链接，可用于图片下载
    /// </summary>
    [JsonProperty("url")]
    public string Url { get; set; }

    /// <summary>
    /// 图片的路径，发送本地图片，路径相对于 JVM 工作路径（默认是当前路径，可通过 -Duser.dir=...指定），也可传入绝对路径。
    /// </summary>
    [JsonProperty("path")]
    public string Path { get; set; }

    /// <summary>
    /// 图片的Base64编码
    /// </summary>
    [JsonProperty("base64")]
    public string Base64 { get; set; }
}