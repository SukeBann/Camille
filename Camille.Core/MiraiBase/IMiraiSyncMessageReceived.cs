using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 收到的同步消息的基本定义
/// https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html#%E5%85%B6%E4%BB%96%E5%AE%A2%E6%88%B7%E7%AB%AF%E6%B6%88%E6%81%AF
/// </summary>
public interface IMiraiSyncMessageReceived
{
    /// <summary>
    /// 收到的同步消息类型
    /// </summary>
    public MiraiSyncMsgChainType SyncReceiveMsgType { get; init; }
}