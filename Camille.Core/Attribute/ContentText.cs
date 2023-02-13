using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Camille.Core.Attribute;

/// <summary>
/// 用于枚举对象, 给枚举值附加一段内容文本字符串信息 
/// </summary>
[AttributeUsage(AttributeTargets.All)]
public class ContentTextAttribute : System.Attribute
{
    #region Properties

    /// <summary>
    /// 默认值
    /// </summary>
    public static readonly ContentTextAttribute Default = new();

    /// <summary>
    /// 文本内容
    /// </summary>
    private string ContentTextValue { get; }

    public string ContentText => ContentTextValue;

    #endregion

    #region Methods

    public ContentTextAttribute() : this(string.Empty)
    {
    }

    public ContentTextAttribute(string contentText) => this.ContentTextValue = contentText;

    #endregion

    #region Obj

    public override bool Equals([NotNullWhen(true)] object? obj) => obj is ContentTextAttribute contentTextAttribute &&
                                                                    contentTextAttribute.ContentText ==
                                                                    ContentText;

    public override int GetHashCode()
    {
        var contentText = ContentText;
        return contentText == null ? 0 : contentText.GetHashCode();
    }

    public override bool IsDefaultAttribute() => Equals(Default);

    #endregion
}