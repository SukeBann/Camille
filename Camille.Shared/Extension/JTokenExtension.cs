using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json.Linq;

namespace Camille.Shared.Extension;

/// <summary>
/// Json-Object-Array-Token的扩展
/// </summary>
public static class JTokenExtension
{
    /// <summary>
    /// 尝试将JToken 转换为 JObject
    /// </summary>
    /// <param name="jToken"></param>
    /// <param name="jObject"></param>
    /// <returns></returns>
    public static bool TryGetJObject(this JToken jToken, [MaybeNullWhen(false)] out JObject jObject)
    {
        jObject = null;
        if (jToken is not JObject jsonObject) return false;

        jObject = jsonObject;
        return true;
    }

    /// <summary>
    /// 获取JToken中指定path的值, 如果获取不到 则返回默认值
    /// </summary>
    /// <param name="path">值路径</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? GetValueOrDefault<T>(this JToken joToken, string path)
    {
        joToken.TryGetValue<T>(path, out var value);
        return value;
    }

    /// <summary>
    /// 尝试获取JToken中指定path的值 
    /// </summary>
    /// <param name="jToken"></param>
    /// <param name="path">值路径</param>
    /// <param name="value">获取到的值</param>
    /// <typeparam name="T"></typeparam>
    /// <returns>如果JToken是JObject并且能获取到指定path的值返回true, 否则返回false</returns>
    public static bool TryGetValue<T>(this JToken jToken, string path, [MaybeNullWhen(false)] out T value)
    {
        value = default;
        return jToken.TryGetJObject(out var jObject) && jObject.TryGetValue<T>(path, out value);
    }

    public static bool TryGetValue<T>(this JObject jObject, string path, [MaybeNullWhen(false)] out T value)
    {
        var tryGetValue = jObject.TryGetValue(path, out var nullableValue);
        value = nullableValue != null ? nullableValue.Value<T>() : default;
        return tryGetValue;
    }
}