using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;
using Newtonsoft.Json;

namespace Camille.Core.MiraiBase.Models.BasicMessage;

/// <summary>
/// 文字消息
/// </summary>
public record Plain : MiraiBasicMessageBase
{
    public override MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.Plain;

    #region Ctor

    /// <summary>
    /// 使用string构造文字消息 
    /// </summary>
    /// <param name="text"></param>
    public Plain(string text)
    {
        Text = text;
    }

    /// <summary>
    /// 构造空文字消息
    /// </summary>
    public Plain()
    {
    }

    #endregion

    #region Convert

    /// <summary>
    /// 将string隐式转换为Plain
    /// </summary>
    /// <param name="text">文本</param>
    /// <returns><see cref="Plain"/></returns>
    public static implicit operator Plain(string text)
    {
        return new Plain(text);
    }

    /// <summary>
    /// 将<see cref="Plain"/> 隐式转换为<see cref="string"/>
    /// </summary>
    /// <param name="plain"></param>
    /// <returns></returns>
    public static implicit operator string(Plain plain)
    {
        return plain.Text;
    }

    #endregion

    /// <summary>
    /// 文本内容
    /// </summary>
    [JsonProperty("text")]
    public string Text { get; set; }
}