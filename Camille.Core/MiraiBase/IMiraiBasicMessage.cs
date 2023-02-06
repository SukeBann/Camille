using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 消息链内基础消息类型定义
/// </summary>
public interface IMiraiBasicMessage
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public MiraiMsgType MiraiMsgType { get; set; }
}