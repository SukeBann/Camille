using System.Diagnostics;
using System.Reactive.Subjects;
using Camille.Core.Adapter;
using Camille.Core.Enum.MiraiBot;
using Camille.Core.Enum.MiraiWebSocket;
using Camille.Core.MiraiBase;
using Camille.Imp.Adapter;
using Camille.Imp.Models.MiraiWebSocket;

namespace Camille.Imp.MiraiBase;

public class MiraiBot : IMiraiBot
{
    public MiraiBot(IMiraiBotConfig miraiBotConfig)
    {
        MiraiBotConfig = miraiBotConfig;
        CancellationTokenSource = new CancellationTokenSource();
        MiraiEventMsgParser = GetMsgParser(miraiBotConfig.ReceiveAdapterType);
    }

    #region Private

    private IMiraiEventMsgParser MiraiEventMsgParser { get; init; }

    private CancellationTokenSource CancellationTokenSource { get; init; }

    #endregion

    #region Properties

    public IMiraiBotConfig MiraiBotConfig { get; init; }

    public Subject<IMiraiEvent> OnMiraiEventReceived => MiraiEventMsgParser.OnMiraiEventReceived;

    public Subject<IMiraiMessageContainer> OnMiraiMessageReceived => MiraiEventMsgParser.OnMiraiMessageReceived;

    #endregion

    public async Task LinkStart()
    {
        await ConnectReceiveAdapter();
    }

    /// <summary>
    /// 根据消息接收适配器获取对应的信息解析器
    /// </summary>
    /// <param name="receiveAdapterType">消息接收适配器类型</param>
    /// <returns></returns>
    private IMiraiEventMsgParser GetMsgParser(ReceiveAdapterType receiveAdapterType)
    {
        // 目前只实现了Ws的信息解析器 所以这里直接返回
        return new MiraiWsEventMsgParser();
    }

    private async Task ConnectReceiveAdapter()
    {
        var address = MiraiBotConfig.ReceiveAdapterServerAddress ??
                      throw new ArgumentException("服务地址为null, 请检查是否设置了信息接收接口适配器");
        var qq = MiraiBotConfig.QQ;
        var verifyKey = MiraiBotConfig.VerifyKey;

        IReceiveDataPublisher? msReceiveDataPublisher;

        switch (MiraiBotConfig.ReceiveAdapterType)
        {
            case ReceiveAdapterType.Websocket:
                var miraiWebSocket = new MiraiWebSocket();
                msReceiveDataPublisher = miraiWebSocket;
                await miraiWebSocket.CreateConnection(new MiraiWebSocketConnectData(address, ConnectChannelType.All,
                    verifyKey, qq), CancellationTokenSource.Token);
                break;
            case ReceiveAdapterType.Http:
            case ReceiveAdapterType.ReverseWebsocket:
            default:
                throw new NotImplementedException("无法使用未实现的消息接收适配器");
        }

        if (msReceiveDataPublisher is null)
        {
            throw new NullReferenceException("消息发布器为null");
        }

        MiraiEventMsgParser.BeginParseData(msReceiveDataPublisher);
    }
}