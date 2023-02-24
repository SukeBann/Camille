using Camille.Core.Adapter;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Core.Models.Exceptions;

namespace Camille.Imp.Extension;

public static class BotMessageExtension
{
    /// <param name="bot">缓存该消息的Bot</param>
    /// <inheritdoc cref="ICommonApiServer.GetMsgById{TMsgContainer}"/>
    public static async Task<TMsgContainer> GetMessageById<TMsgContainer>(this IMiraiBot bot, int messageId, long target)
        where TMsgContainer : class, IMiraiMessageContainer
    {
        return await bot.CommonApiServer.GetMsgById<TMsgContainer>(messageId, target);
    }

    /// <param name="bot">发送信息的bot</param>
    /// <inheritdoc cref="ICommonApiServer.SendFriendMessage"/>
    public static async Task<int> SendFriendMsg(this IMiraiBot bot, long qq, MessageChain messageChain)
    {
        return await bot.CommonApiServer.SendFriendMessage(qq, messageChain);
    }

    /// <param name="bot">发送信息的bot</param>
    /// <inheritdoc cref="ICommonApiServer.SendGroupMessage"/>
    public static async Task<int> SendGroupMsg(this IMiraiBot bot, long target, MessageChain messageChain)
    {
        return await bot.CommonApiServer.SendGroupMessage(target, messageChain);
    }

    /// <summary>
    /// 引用指定的消息, 必须指定是引用好友聊天消息还是群聊天消息
    /// </summary>
    /// <param name="bot">发送消息的bot</param>
    /// <param name="messageChain">引用消息时 要附加的消息</param>
    /// <param name="msgType">消息类型： 好友消息， 群聊消息</param>
    /// <param name="target">如果引用好友聊天消息, 则指定好友qq, 否则指定群聊id</param>
    /// <param name="messageId">要引用的消息id</param>
    /// <returns></returns>
    /// <exception cref="MiraiException">消息id异常时抛出</exception>
    /// <exception cref="ArgumentOutOfRangeException">消息类型异常时抛出</exception>
    public static async Task<int> QuoteMessage(this IMiraiBot bot,
        MiraiSubjectType msgType,
        long target,
        int messageId,
        MessageChain messageChain)
    {
        if (messageId < 1)
        {
            throw new MiraiException("请指定正确的消息id", MiraiExceptionType.UnKnownException);
        }
        return msgType switch
        {
            MiraiSubjectType.Friend => await bot.CommonApiServer.SendFriendMessage(target, messageChain, messageId),
            MiraiSubjectType.Group => await bot.CommonApiServer.SendGroupMessage(target, messageChain, messageId),
            _ => throw new ArgumentOutOfRangeException(nameof(msgType), msgType, null)
        };
    }
}