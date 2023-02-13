using System.Net;
using System.Reactive.Linq;
using Camille.Core.Enum.MiraiWebSocket;
using Camille.Core.MiraiBase;
using Camille.Imp.Adapter;
using Camille.Imp.MiraiBase;
using Camille.Imp.MiraiBase.Message.BasicMessage;
using Camille.Imp.MiraiBase.Message.MessageContainer;
using Camille.Imp.Models.MiraiWebSocket;
using Masuit.Tools;

var cancellationTokenSource = new CancellationTokenSource();

var miraiWebSocket = new MiraiWebSocket();
IMiraiEventMsgParser miraiEventMsgParser = new MiraiEventMsgParser();

miraiEventMsgParser.BeginParseData(miraiWebSocket);

await miraiWebSocket.CreateConnection(new MiraiWebSocketConnectData(8080,
        IPAddress.Parse("127.0.0.1"),
        ConnectChannelType.All,
        "1234567890",
        1197884312),
    cancellationTokenSource.Token);

miraiEventMsgParser.OnMiraiEventReceived.Subscribe(miraiEvent =>
{
    Console.WriteLine($"mirai event: {miraiEvent.EventType}");
});

miraiEventMsgParser.OnMiraiMessageReceived
    .OfType<GroupMiraiMsgContainer>()
    .Subscribe(miraiMsg =>
    {
        var senderGroup = miraiMsg.Sender.Group;
        Console.WriteLine(
            $"mirai msg: [{senderGroup.Name}]{miraiMsg.Sender.MemberName}: {miraiMsg.MessageChain.GetPlainMessage()} Image: {miraiMsg.MessageChain.OfType<Image>().ToJsonString()}");
    });

miraiEventMsgParser.OnMiraiMessageReceived
    .OfType<FriendMiraiMsgContainer>()
    .Subscribe(miraiMsg =>
    {
        var sender = miraiMsg.Sender;
        Console.WriteLine(
            $"mirai msg: [{sender.Nickname}]: {miraiMsg.MessageChain.GetPlainMessage()} Image: {miraiMsg.MessageChain.OfType<Image>().ToJsonString()}");
    });

Console.ReadKey();