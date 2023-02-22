using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Shared.Extension;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Camille.Imp.MiraiBase.Tools.JsonConverter;

public class MiraiMessageChainConverter : Newtonsoft.Json.JsonConverter
{
    #region Properties

    /// <summary>
    /// 支持自定义的反序列化
    /// </summary>
    /// <inheritdoc/>
    public override bool CanRead => true;

    /// <summary>
    /// 该转换器不支持自定义序列化
    /// </summary>
    /// <inheritdoc/>
    public override bool CanWrite => false;

    #endregion

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// 获取基础信息的实例类型
    /// </summary>
    /// <param name="identityTypeName">基础消息的标识类型文本, 例如： At, Quote</param>
    /// <returns></returns>
    private Type GetBasicMsgType(string identityTypeName)
    {
        return MiraiDataReflection.MiraiBasicMsgTypeMapping.TryGetValue(identityTypeName,
            out var typeMapping)
            ? typeMapping.InstanceType
            : typeof(UnKnownBasicMsg);
    }

    /// <summary>
    /// 获取基础消息实例
    /// </summary>
    /// <param name="reader">json Reader</param>
    /// <param name="item">基础消息jToken</param>
    /// <returns></returns>
    private IMiraiBasicMessage GetBasicMsg(JsonReader reader, JToken item)
    {
        try
        {
            if (!item.TryGetJObject(out var jObject) || !jObject.TryGetValue<string>("type", out var value))
                return new UnKnownBasicMsg(reader.Value?.ToString() ?? string.Empty);

            var basicMsgType = GetBasicMsgType(value);
            return (JsonConvert.DeserializeObject(item.ToString(), basicMsgType) as MiraiBasicMessageBase) ??
                   (IMiraiBasicMessage) new UnKnownBasicMsg(reader.Value?.ToString() ?? string.Empty);
        }
        catch (Exception e)
        {
            return new UnKnownBasicMsg(reader.Value?.ToString() ?? string.Empty);
        }
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue,
        JsonSerializer serializer)
    {
        var messageChain = new MessageChain();
        var messageChainJArray = serializer.Deserialize<JArray>(reader) ?? new JArray();

        messageChain.AddRange(messageChainJArray.Select(item => GetBasicMsg(reader, item)));
        return messageChain;
    }

    public override bool CanConvert(Type objectType)
    {
        return typeof(MessageChain) == objectType;
    }
}