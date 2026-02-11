using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.Enum.MiraiBot;
using Camille.Core.Enum.MiraiWebSocket;
using Camille.Core.MiraiBase;
using Camille.Imp.Extension;
using Camille.Imp.MiraiBase;
using Camille.Imp.MiraiBase.Message.MessageContainer;
using Camille.Imp.Models.MiraiWebSocket;
using Camille.Logger.Config;
using Websocket.Client;

namespace Camille.Test;

public class Tests
{
    public Tests()
    {
        Shared.Logger.InitLogger(new LogConfig(Path.Combine(Environment.CurrentDirectory, "Camille.log"), 30));

        _bot = MiraiBotFactory.CreateBotConfig(1197884312, "INITKEYhzr2Rn32")
            .AddReceiveAdapter(ReceiveAdapterType.Websocket, "127.0.0.1:8089")
            .AddApiAdapter(ApiAdapterType.Http, "127.0.0.1:8089")
            .BuildBot();
    }

    private IMiraiBot _bot;

    private const string MessageContent = "test message";
    private int _groupMsgId;
    private int _friendMsgId;
    private readonly int _groupId = 749396837;
    private const int _friendId = 1052700448;

    /// <summary>
    /// 启动Bot
    /// </summary>
    [Test]
    public async Task BotLaunch()
    {
        await _bot.LinkStart();
    }

    [Test]
    public async Task WsClientTest()
    {
        // TestContext.WriteLine("开始连接 WebSocket...");
        //
        // var qq = 1197884312;
        // var verifyKey = "INITKEYhzr2Rn32";
        //
        // var miraiWebSocket = new MiraiWebSocket();
        // TestContext.WriteLine($"创建连接: {qq}");
        //
        // var cancellationTokenSource = new CancellationTokenSource();
        // var receiveDataPublisher = miraiWebSocket;
        // var miraiWsEventMsgParser = new MiraiWsEventMsgParser();
        // miraiWsEventMsgParser.BeginParseData(receiveDataPublisher);
        //
        // await miraiWebSocket.CreateConnection(new MiraiWebSocketConnectData("localhost:8089", ConnectChannelType.All,
        //     verifyKey, qq), cancellationTokenSource.Token);
        //
        // TestContext.WriteLine("连接成功,等待60秒...");
        var websocketClient = new WebsocketClient(new Uri("ws://localhost:8089/all?qq=1197884312&verifyKey=INITKEYhzr2Rn32"))
        {
            IsReconnectionEnabled = true,
            ReconnectTimeout = null
        };
        websocketClient.MessageReceived.Subscribe(msg =>
        {
            Shared.Logger.Info($"receive msg: {msg}");
        });
        await websocketClient.StartOrFail();
        Console.ReadLine();
    }


    /// <summary>
    /// 群信息发送
    /// </summary>
    public async Task SendGroupMsg()
    {
        var sendGroupMsg = await _bot.SendGroupMsg(_groupId, MessageContent);
        Assert.That(sendGroupMsg, Is.GreaterThanOrEqualTo(1));
        _groupMsgId = sendGroupMsg;

        await Task.Delay(1000);
    }

    /// <summary>
    /// 好友信息发送
    /// </summary>
    public async Task SendFriendMsg()
    {
        var sendFriendMsg = await _bot.SendFriendMsg(_friendId, MessageContent);
        Assert.That(sendFriendMsg, Is.GreaterThanOrEqualTo(1));
        _friendMsgId = sendFriendMsg;

        await Task.Delay(1000);
    }

    /// <summary>
    /// 根据发送的好友与群信息id获取信息实例 
    /// </summary>
    [Test]
    public async Task GetMessageById()
    {
        await SendGroupMsg();
        await SendFriendMsg();

        var groupMiraiMsgContainer = await _bot.GetMessageById<GroupMiraiMsgContainer>(_groupMsgId, _groupId);
        var friendMiraiMsgContainer = await _bot.GetMessageById<FriendMiraiMsgContainer>(_friendMsgId, _friendId);
        Assert.Multiple(() =>
        {
            Assert.That(groupMiraiMsgContainer.MessageChain.GetPlainMessage(), Is.EqualTo(MessageContent));
            Assert.That(friendMiraiMsgContainer.MessageChain.GetPlainMessage(), Is.EqualTo(MessageContent));
        });
    }

    /// <summary>
    /// 消息引用回复
    /// </summary>
    [Test]
    public async Task QuoteMessage()
    {
        await SendGroupMsg();
        await SendFriendMsg();

        var friendQuoteId =
            await _bot.QuoteMessage(MiraiSubjectType.Friend, _friendId, _friendMsgId, "quote message test");
        var groupQuoteId = await _bot.QuoteMessage(MiraiSubjectType.Group, _groupId, _groupMsgId, "quote message test");

        Assert.Multiple(() =>
        {
            Assert.That(friendQuoteId, Is.GreaterThanOrEqualTo(1));
            Assert.That(groupQuoteId, Is.GreaterThanOrEqualTo(1));
        });
    }
}