namespace Camille.Core.Attribute.ExtensionMethod;

public static class AttributeExtension
{
    public static string? GetContentText(this object target)
    {
        var type = target.GetType();
        var fieldInfo = type.GetField(target.ToString());
        var customAttribute = fieldInfo.GetCustomAttributes(typeof(ContentTextAttribute), true).FirstOrDefault();
        return ((ContentTextAttribute) customAttribute)?.ContentText;
    }
}