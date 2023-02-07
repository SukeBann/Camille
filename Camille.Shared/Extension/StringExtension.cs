using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SixLabors.Fonts.Tables.TrueType;

namespace Camille.Client.Extension;

public static class StringExtension
{
    /// <summary>
    /// 如果json文本可以解析为JObject则返回true, 否则返回false
    /// </summary>
    /// <param name="jsonText">要解析的json文本</param>
    /// <param name="jToken">如果能解析则返回JToken, 否则返回null</param>
    /// <returns></returns>
    public static bool TryGetJObject(this string jsonText, out JToken? jToken)
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
    /// 判断是否为正确的json文本
    /// </summary>
    /// <param name="jsonText">要解析的json文本</param>
    /// <returns></returns>
    public static bool IsValidJson(this string jsonText)
    {
        return TryGetJObject(jsonText, out _);
    }
}