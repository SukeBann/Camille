using Camille.Core.Enum.MiraiBaseEnum;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 消息链内消息的类型
/// </summary>
public interface IMiraiMessage
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public MiraiMsgType MiraiMsgType { get; set; }
}