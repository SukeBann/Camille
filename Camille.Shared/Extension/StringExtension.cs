using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace Camille.Shared.Extension;

public static class StringExtension
{
    /// <summary>
    /// 如果json文本可以解析为JObject则返回true, 否则返回false
    /// </summary>
    /// <param name="jsonText">要解析的json文本</param>
    /// <param name="jToken">如果能解析则返回JToken, 否则返回null</param>
    /// <returns></returns>
    public static bool TryGetJToken(this string jsonText, [MaybeNullWhen(false)] out JToken jToken)
    {
        jToken = null;
        try
        {
            jToken = JToken.Parse(jsonText);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public static bool TryGetValue<T>(this JObject jObject, string path, [MaybeNullWhen(false)]out T value)
    where T: class
    {
        var tryGetValue = jObject.TryGetValue(path, out var nullableValue);
        value = nullableValue?.Value<T>();
        return tryGetValue;
    }

    /// <summary>
    /// 判断是否为正确的json文本
    /// </summary>
    /// <param name="jsonText">要解析的json文本</param>
    /// <returns></returns>
    public static bool IsValidJson(this string jsonText)
    {
        return TryGetJToken(jsonText, out _);
    }
}