using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Camille.Core.Adapter;
using Camille.Core.Models.MiraiWebSocket;
using Camille.Logger;
using Masuit.Tools;
using Websocket.Client;

namespace Camille.Imp.Adapter;

/// <summary>
/// <see cref="IMiraiWebSocket"/>功能实现， 提供与mirai建立连接， 接受事件与消息的功能.
/// </summary>
public class MiraiWebSocket : IMiraiWebSocket, IReceiveDataPublisher
{
    public MiraiWebSocket(ILogger logger)
    {
        Logger = logger;
    }

    #region Properties

    private ILogger Logger { get; }

    /// <summary>
    /// ws 客户端, 每个qq一个单独的实例
    /// </summary>
    private WebsocketClient? MiraiWebsocketClient { get; set; }

    /// <inheritdoc/>
    public Subject<WebSocketCloseStatus> OnWsDisconnect { get; } = new();
    
    /// <inheritdoc/>
    public Subject<string> OnWsReceiveMsg { get; } = new();

    #endregion

    /// <inheritdoc/> 
    public async Task CreateConnection(IMiraiWebSocketConnectData connectData,
        CancellationToken cancellationToken)
    {
        try
        {
            MiraiWebsocketClient = new WebsocketClient(connectData.ConnectUri)
            {
                IsReconnectionEnabled = false
            };

            await MiraiWebsocketClient.StartOrFail();

            // 当连接断开时推送事件
            MiraiWebsocketClient.DisconnectionHappened.Subscribe(x =>
            {
                OnWsDisconnect.OnNext(x.CloseStatus ?? WebSocketCloseStatus.Empty);
            });

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
        }
        catch (Exception e)
        {
            if (e is TaskCanceledException)
            {
                return;
            }

            Logger.Error("on MiraiWebSocket connect error", e);
        }
    }
}