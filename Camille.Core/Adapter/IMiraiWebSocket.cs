using Camille.Core.Models.MiraiWebSocket;


namespace Camille.Core.Adapter;

/// <summary>
/// 提供与mirai建立连接,接受事件与消息的功能定义.
/// </summary>
public interface IMiraiWebSocket
{
    public Task CreateConnection(IMiraiWebSocketConnectData connectData, CancellationToken cancellationToken);
}