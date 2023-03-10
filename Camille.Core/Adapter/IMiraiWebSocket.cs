using System.Net.WebSockets;
using System.Reactive.Subjects;
using Camille.Core.Models.MiraiWebSocket;


namespace Camille.Core.Adapter;

/// <summary>
/// 提供与mirai建立连接,接受事件与消息的功能定义.
/// </summary>
public interface IMiraiWebSocket
{
    /// <summary>
    /// 创建ws连接
    /// </summary>
    /// <param name="connectData">连接参数</param>
    /// <param name="cancellationToken">异步取消令牌</param>
    /// <returns></returns>
    public Task CreateConnection(IMiraiWebSocketConnectData connectData, CancellationToken cancellationToken);
}