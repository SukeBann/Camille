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

var bot = MiraiBotFactory.CreateBotConfig(1197884312, "123456789")
    .AddReceiveAdapter(ReceiveAdapterType.Websocket, "127.0.0.1:8080")
    .AddApiAdapter(ApiAdapterType.Http, "127.0.0.1:8080")
    .BuildBot();

bot.OnMiraiEventReceived.Subscribe(x => { Logger.Info($"[EVENT]: [{x.EventType}]"); });

bot.OnMiraiMessageReceived
    .OfType<GroupMiraiMsgContainer>()
    .Where(x => x.Sender.Group.Id == 587914615)
    .Where(x => x.MessageChain.GetPlainMessage()
                    .Contains("吗") ||
                x.MessageChain.GetPlainMessage()
                    .Contains("?") ||
                x.MessageChain.GetPlainMessage()
                    .Contains("？"))
    .Subscribe(async x =>
    {
        x.MessageChain.OfType<Plain>().ForEach(x => x.Text = x.Text
            .Replace("?", "")
            .Replace("？", "")
            .Replace("吗", "!")
        );
        await bot.SendGroupMsg(x.Sender.Group.Id, x.MessageChain);
    });

await bot.LinkStart();

manualResetEvent.WaitOne();