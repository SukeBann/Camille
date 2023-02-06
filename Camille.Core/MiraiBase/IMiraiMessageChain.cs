using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 消息链的基本定义
/// </summary>
public interface IMiraiMessageChain
{
    /// <summary>
    /// 消息链类型
    /// </summary>
    public MiraiMsgChainType MsgChainType { get; set; }
}