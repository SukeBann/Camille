using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 消息链内基础消息类型定义
/// https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html#%E6%B6%88%E6%81%AF%E7%B1%BB%E5%9E%8B
/// </summary>
public interface IMiraiBasicMessage
{
    /// <summary>
    /// 消息类型
    /// </summary>
    public MiraiBasicMsgType MiraiBasicMsgType { get; init; }
}