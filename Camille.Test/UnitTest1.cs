using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.Enum.MiraiBot;
using Camille.Core.MiraiBase;
using Camille.Imp.Extension;
using Camille.Imp.MiraiBase;
using Camille.Imp.MiraiBase.Message.MessageContainer;
using Camille.Logger.Config;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Camille.Test;

public class Tests
{
    public Tests()
    {
        Shared.Logger.InitLogger(new LogConfig(Path.Combine(Environment.CurrentDirectory, "Camille.log"), 30));

        _bot = MiraiBotFactory.CreateBotConfig(1197884312, "123456789")
            .AddReceiveAdapter(ReceiveAdapterType.Websocket, "127.0.0.1:8080")
            .AddApiAdapter(ApiAdapterType.Http, "127.0.0.1:8080")
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
        _friendMsgId =sendFriendMsg;
        
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

        var friendQuoteId = await _bot.QuoteMessage(MiraiSubjectType.Friend, _friendId, _friendMsgId, "quote message test");
        var groupQuoteId = await _bot.QuoteMessage(MiraiSubjectType.Group, _groupId, _groupMsgId, "quote message test");
        
        Assert.Multiple(() =>
        {
            Assert.That(friendQuoteId, Is.GreaterThanOrEqualTo(1));
            Assert.That(groupQuoteId, Is.GreaterThanOrEqualTo(1));
        });
    }
}