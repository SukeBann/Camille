﻿using System.Net.WebSockets;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using Camille.Core.Adapter;
using Camille.Core.Models.MiraiWebSocket;
using Camille.Logger;
using Websocket.Client;

namespace Camille.Imp.Adapter;

/// <summary>
/// <see cref="IMiraiWebSocket"/>功能实现， 提供与mirai建立连接， 接受事件与消息的功能.
/// </summary>
public partial class MiraiWebSocket : IMiraiWebSocket
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
    private WebsocketClient MiraiWebsocketClient { get; set; }

    /// <summary>
    /// Ws断开连接时推送消息
    /// </summary>
    public Subject<WebSocketCloseStatus> OnWsDisconnect { get; } = new();

    #endregion

    /// <summary>
    /// ws创建连接
    /// </summary>
    /// <param name="connectData">连接参数</param>
    /// <param name="cancellationToken">取消令牌</param>
    /// <returns></returns>
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

            MiraiWebsocketClient.DisconnectionHappened.Subscribe(x =>
            {
                OnWsDisconnect.OnNext(x.CloseStatus ?? WebSocketCloseStatus.Empty);
            });

            MiraiWebsocketClient.MessageReceived
                // 因为Mirai-Http发送过来的数据都是文本格式，所以在这里过滤文本消息
                .Where(x => x.MessageType == WebSocketMessageType.Text)
                .Subscribe(message =>
                {
                    var data = message.Text.Fetch
                });
        }
        catch (Exception e)
        {
            if (e is TaskCanceledException)
            {
                return;
            }

            Logger.Error("create MiraiWebSocket error", e);
        }
    }
}