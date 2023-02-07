using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 收到的消息的基本定义
/// https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html
/// </summary>
public interface IMiraiMessageReceived
{
    /// <summary>
    /// 收到的消息类型
    /// </summary>
    public MiraiReceiveMsgType ReceiveMsgType { get; init; }
}