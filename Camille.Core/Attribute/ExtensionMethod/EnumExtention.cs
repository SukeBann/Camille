using Camille.Core.Enum.CommonInterfaceEnum;
using Masuit.Tools.Reflection;

namespace Camille.Core.Attribute.ExtensionMethod;

public static class AttributeExtension
{
    /// <summary>
    /// 获取<see cref="ContentTextAttribute"/>中的文本内容
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static string? GetContentText(this object target)
    {
        var type = target.GetType();
        var fieldInfo = type.GetField(target.ToString());
        var customAttribute = fieldInfo?.GetAttribute<ContentTextAttribute>();
        return customAttribute?.ContentText;
    }

    /// <summary>
    /// 判断<see cref="HttpEndpoints"/>是否需要会话秘钥验证
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    public static bool IsNeedVerify(this object target)
    {
        var type = target.GetType();
        var fieldInfo = type.GetField(target.ToString());
        var customAttribute = fieldInfo?.GetAttribute<VerificationRequiredAttribute>();
        return customAttribute is not null;
    }
}