using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Models.Base;

namespace Camille.Core.MiraiBase.Contract;

/// <summary>
/// 收到的消息容器的基本定义
/// https://docs.mirai.mamoe.net/mirai-api-http/api/MessageType.html
/// </summary>
public interface IMiraiMessageContainer
{
    /// <summary>
    /// 收到的消息类型
    /// </summary>
    public MiraiContainerMsgType ContainerMsgType { get; init; }
    
    /// <summary>
    /// 消息链内容体
    /// </summary>
    public MessageChain MessageChain { get; set; }
}