using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Imp.MiraiBase.Message;

/// <summary>
/// 未知基础信息
/// </summary>
public class UnKnownBasicMsg : IMiraiBasicMessage, IMiraiUnknownData
{
    public UnKnownBasicMsg(string sourceData)
    {
        SourceData = sourceData;
    }

    [JsonProperty("type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public MiraiBasicMsgType MiraiBasicMsgType { get; init; } = MiraiBasicMsgType.UnKnown;

    /// <summary>
    /// 源数据
    /// </summary>
    public string SourceData { get; init; }
}