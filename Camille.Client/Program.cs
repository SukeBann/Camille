using System.Net;
using Camille.Core.Enum.MiraiWebSocket;
using Camille.Core.MiraiBase;
using Camille.Imp.Adapter;
using Camille.Imp.MiraiBase;
using Camille.Imp.Models.MiraiWebSocket;

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

miraiEventMsgParser.OnMiraiMessageReceived.Subscribe(miraiMsg =>
{
    Console.WriteLine($"mirai msg: {miraiMsg.ReceiveMsgType}");
});

Console.ReadKey();