using System.Reactive.Linq;
using Camille.Core.Enum.MiraiBot;
using Camille.Core.MiraiBase.Models.BasicMessage;
using Camille.Imp.Extension;
using Camille.Imp.MiraiBase;
using Camille.Imp.MiraiBase.Message.MessageContainer;
using Camille.Logger.Config;
using Camille.Shared;
using Masuit.Tools;

var manualResetEvent = new ManualResetEvent(false);

Logger.InitLogger(new LogConfig(Path.Combine(Environment.CurrentDirectory, "Camille.log"), 30));

var bot = MiraiBotFactory.CreateBotConfig(1197884312, "INITKEYhzr2Rn32")
    .AddReceiveAdapter(ReceiveAdapterType.Websocket, "localhost:8089")
    .AddApiAdapter(ApiAdapterType.Http, "localhost:8089")
    .BuildBot();

bot.OnMiraiEventReceived.Subscribe(x => { Logger.Info($"[EVENT]: [{x.EventType}]"); });

bot.OnMiraiMessageReceived
    .OfType<FriendMiraiMsgContainer>()
    .Where(x => x.Sender.Id == 1052700448)
    .Subscribe(async x =>
    {
        await bot.SendFriendMsg(x.Sender.Id, x.MessageChain);
    });

await bot.LinkStart();

manualResetEvent.WaitOne();