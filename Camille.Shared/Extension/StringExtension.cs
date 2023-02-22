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

    /// <summary>
    /// 尝试从json文本中获取指定path的值
    /// </summary>
    /// <param name="jsonText">json文本</param>
    /// <param name="path">json property name</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? GetJsonValue<T>(this string jsonText, string path)
    {
        return jsonText.TryGetJToken(out var jToken) ? jToken.GetValueOrDefault<T>(path) : default;
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