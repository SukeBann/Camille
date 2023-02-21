using System.Reactive.Linq;
using Camille.Core.Enum.MiraiBot;
using Camille.Imp.MiraiBase;
using Camille.Imp.MiraiBase.Message.MessageContainer;
using Camille.Logger.Config;
using Camille.Shared;

var manualResetEvent = new ManualResetEvent(false);

Logger.InitLogger(new LogConfig(Path.Combine(Environment.CurrentDirectory, "Camille.log"), 30));

var bot = MiraiBotFactory.CreateBotConfig(1197884312, "1234567890")
    .AddReceiveAdapter(ReceiveAdapterType.Websocket, "127.0.0.1:8080")
    .AddApiAdapter(ApiAdapterType.Http, "127.0.0.1:8080")
    .BuildBot();

bot.OnMiraiEventReceived.Subscribe(x =>
{
    Logger.Info($"[EVENT]: [{x.EventType}]");
});

bot.OnMiraiMessageReceived
    .OfType<GroupMiraiMsgContainer>()
    .Subscribe(x =>
{
    Logger.Info($"[MSG] [{x.Sender.Group.Name}] {x.Sender.MemberName} --> {x.MessageChain.GetPlainMessage()}");
});

await bot.LinkStart();

manualResetEvent.WaitOne();