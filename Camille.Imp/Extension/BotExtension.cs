using Camille.Core.Adapter;
using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Models.Base;

namespace Camille.Imp.Extension;

public static class BotExtension
{
    /// <param name="bot">发送信息的bot</param>
    /// <inheritdoc cref="ICommonApiServer.SendFriendMessage"/>
    public static async Task<int> SendFriendMsg(this IMiraiBot bot, long qq, MessageChain messageChain)
    {
        return await bot.CommonApiServer.SendFriendMessage(qq, messageChain);
    }
    
    /// <param name="bot">发送信息的bot</param>
    /// <inheritdoc cref="ICommonApiServer.SendGroupMessage"/>
    public static async Task<int> SendGroupMsg(this IMiraiBot bot, long targe, MessageChain messageChain)
    {
        return await bot.CommonApiServer.SendGroupMessage(targe, messageChain);
    }
}