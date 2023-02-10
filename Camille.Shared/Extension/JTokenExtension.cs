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
}