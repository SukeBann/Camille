using Camille.Core.Adapter;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Contract;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Core.MiraiBase.Models.CommonApi;
using Camille.Core.Models.Exceptions;

namespace Camille.Imp.Extension;

public static class BotMessageExtension
{
    #region 插件信息

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.About"/>
    public static async Task<string> GetAbout(this IMiraiBot bot)
    {
        return await bot.Api.About();
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetBotList"/>
    public static async Task<List<long>> GetBotList(this IMiraiBot bot)
    {
        return await bot.Api.GetBotList();
    }

    #endregion

    #region 缓存操作

    /// <param name="bot">缓存该消息的Bot</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetMsgById{TMsgContainer}"/>
    public static async Task<TMsgContainer> GetMessageById<TMsgContainer>(this IMiraiBot bot, int messageId,
        long target)
        where TMsgContainer : class, IMiraiMessageContainer
    {
        return await bot.Api.GetMsgById<TMsgContainer>(messageId, target);
    }

    #endregion

    #region 获取账号信息

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetFriendList"/>
    public static async Task<List<Account>> GetFriendList(this IMiraiBot bot)
    {
        return await bot.Api.GetFriendList();
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetGroupList"/>
    public static async Task<List<Group>> GetGroupList(this IMiraiBot bot)
    {
        return await bot.Api.GetGroupList();
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetMemberList"/>
    public static async Task<List<GroupMember>> GetMemberList(this IMiraiBot bot, long groupId)
    {
        return await bot.Api.GetMemberList(groupId);
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetLatestMemberList"/>
    public static async Task<List<GroupMember>> GetLatestMemberList(this IMiraiBot bot, long groupId,
        List<long> memberIds)
    {
        return await bot.Api.GetLatestMemberList(groupId, memberIds);
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetBotProfile"/>
    public static async Task<UserProfile> GetBotProfile(this IMiraiBot bot)
    {
        return await bot.Api.GetBotProfile();
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetFriendProfile"/>
    public static async Task<UserProfile> GetFriendProfile(this IMiraiBot bot, long target)
    {
        return await bot.Api.GetFriendProfile(target);
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetMemberProfile"/>
    public static async Task<UserProfile> GetMemberProfile(this IMiraiBot bot, long target, long memberId)
    {
        return await bot.Api.GetMemberProfile(target, memberId);
    }

    /// <param name="bot">Bot实例</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetUserProfile"/>
    public static async Task<UserProfile> GetUserProfile(this IMiraiBot bot, long target)
    {
        return await bot.Api.GetUserProfile(target);
    }

    #endregion

    #region 消息发送与撤回

    /// <param name="bot">发送信息的bot</param>
    /// <inheritdoc cref="IMiraiCommonApi.SendFriendMessage"/>
    public static async Task<int> SendFriendMsg(this IMiraiBot bot, long qq, MessageChain messageChain)
    {
        return await bot.Api.SendFriendMessage(qq, messageChain);
    }

    /// <param name="bot">发送信息的bot</param>
    /// <inheritdoc cref="IMiraiCommonApi.SendGroupMessage"/>
    public static async Task<int> SendGroupMsg(this IMiraiBot bot, long target, MessageChain messageChain)
    {
        return await bot.Api.SendGroupMessage(target, messageChain);
    }

    /// <param name="bot">发送信息的bot</param>
    /// <inheritdoc cref="IMiraiCommonApi.SendTempMessage"/>
    public static async Task<int> SendTempMsg(this IMiraiBot bot, long qq, long group, MessageChain messageChain)
    {
        return await bot.Api.SendTempMessage(qq, group, messageChain);
    }

    /// <param name="bot">发送戳一戳的bot</param>
    /// <inheritdoc cref="IMiraiCommonApi.SendNudge"/>
    public static async Task<bool> SendNudge(this IMiraiBot bot, long target, long subject, string kind)
    {
        return await bot.Api.SendNudge(target, subject, kind);
    }

    /// <param name="bot">撤回消息的bot</param>
    /// <inheritdoc cref="IMiraiCommonApi.RecallMessage"/>
    public static async Task<bool> RecallMessage(this IMiraiBot bot, int messageId, long target)
    {
        return await bot.Api.RecallMessage(messageId, target);
    }

    /// <param name="bot">获取漫游消息的bot</param>
    /// <inheritdoc cref="IMiraiCommonApi.GetRoamingMessages"/>
    public static async Task<List<MessageChain>> GetRoamingMessages(this IMiraiBot bot, long timeStart, long timeEnd,
        long target)
    {
        return await bot.Api.GetRoamingMessages(timeStart, timeEnd, target);
    }

    #endregion

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
            MiraiSubjectType.Friend => await bot.Api.SendFriendMessage(target, messageChain, messageId),
            MiraiSubjectType.Group => await bot.Api.SendGroupMessage(target, messageChain, messageId),
            _ => throw new ArgumentOutOfRangeException(nameof(msgType), msgType, null)
        };
    }
}