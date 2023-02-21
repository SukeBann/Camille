using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Camille.Core.Adapter;
using Camille.Core.Models;
using Camille.Core.Models.MiraiWebSocket;
using Masuit.Tools;
using Websocket.Client;

namespace Camille.Imp.Adapter;

/// <summary>
/// <see cref="IMiraiWebSocket"/>功能实现， 提供与mirai建立连接， 接受事件与消息的功能.
/// </summary>
public class MiraiWebSocket : IMiraiWebSocket, IReceiveDataPublisher
{
    public MiraiWebSocket()
    {
    }

    #region Properties

    /// <summary>
    /// ws 客户端, 每个qq一个单独的实例
    /// </summary>
    private WebsocketClient? MiraiWebsocketClient { get; set; }

    /// <inheritdoc/>
    public Subject<string> OnWsReceiveMsg { get; } = new();

    #endregion

    /// <inheritdoc/> 
    public async Task CreateConnection(IMiraiWebSocketConnectData connectData,
        CancellationToken cancellationToken)
    {
        try
        {
            var miraiWebsocketClient = CreateWsClient(connectData.WsConnectUri);
            
            await miraiWebsocketClient.StartOrFail();
        }
        catch (Exception e)
        {
            if (e is TaskCanceledException)
            {
                return;
            }

            Shared.Logger.Error($"on {nameof(MiraiWebSocket)} connect error", e);
            throw;
        }
    }

    /// <summary>
    /// 创建一个新的WsClient并且订阅接收到的文本信息,
    /// <br/>订阅连接断开事件, 记录日志,
    /// <br/>并添加尝试重连机制
    /// </summary>
    /// <param name="serverAddress">要连接到的Server地址</param>
    /// <returns></returns>
    private WebsocketClient CreateWsClient(Uri serverAddress)
    {
        MiraiWebsocketClient = new WebsocketClient(serverAddress)
        {
            IsReconnectionEnabled = false
        };

        // 当连接断开时推送事件
        MiraiWebsocketClient.DisconnectionHappened.Subscribe(x =>
        {
            var webSocketCloseStatus = x.CloseStatus ?? WebSocketCloseStatus.Empty;
            Shared.Logger.Error($"{nameof(MiraiWebSocket)}断开连接, 原因：{webSocketCloseStatus}");
        });

        // 默认重连超时为1分钟, 这里修改为30秒
        MiraiWebsocketClient.ErrorReconnectTimeout = TimeSpan.FromSeconds(30);
        MiraiWebsocketClient.ReconnectTimeout = TimeSpan.FromSeconds(30);
        MiraiWebsocketClient.ReconnectionHappened.Subscribe(x =>
            Shared.Logger.Info($"{nameof(MiraiWebSocket)} reconnect type: {x.Type}"));

        // 当接收到消息时推送事件
        MiraiWebsocketClient.MessageReceived
            // 因为Mirai-Http发送过来的数据都是文本格式，所以在这里过滤文本消息
            .Where(x => x.MessageType == WebSocketMessageType.Text)
            .Subscribe(message =>
            {
                if (message.Text.IsNullOrEmpty())
                {
                    return;
                }

                OnWsReceiveMsg.OnNext(message.Text);
            });

        return MiraiWebsocketClient;
    }
}