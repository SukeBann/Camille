using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// Mirai消息链内的基础消息类型
/// https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html#%E6%B6%88%E6%81%AF%E7%B1%BB%E5%9E%8B
/// </summary>
public enum MiraiBasicMsgType
{
    /// <summary>
    /// 消息的识别号，用于引用回复（Source类型永远为chain的第一个元素）
    /// </summary>
    [Description("消息识别源")]
    Source,
    [Description("引用")]
    Quote,
    [Description("At")]
    At,
    [Description("AtAll")]
    AtAll,
    [Description("QQ表情")]
    Face,
    [Description("文字消息")]
    Plain,
    [Description("图片")]
    Image,
    [Description("闪照")]
    FlashImage,
    [Description("语音")]
    Voice,
    [Description("XML文本")]
    Xml,
    [Description("Json文本")]
    Json,
    [Description("内容")]
    App,
    /// <summary>
    /// 戳一戳的类型 具体的戳一戳有很多种
    /// </summary>
    [Description("戳一戳")]
    Poke,
    [Description("点数")]
    Dice,
    [Description("商城表情")]
    MarketFace,
    [Description("音乐分享")]
    MusicShare,
    [Description("合并转发消息")]
    ForwardMessage,
    [Description("文件")]
    File,
    [Description("MiraiCode")]
    MiraiCode
}