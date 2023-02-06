using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 收到的消息的基本定义
/// </summary>
public interface IMiraiMessageReceived
{
    /// <summary>
    /// 消息链类型
    /// </summary>
    public MiraiReceiveMsgType ReceiveMsgType { get; set; }
}