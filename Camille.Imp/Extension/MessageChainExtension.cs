using Camille.Core.MiraiBase.Contract;
using Camille.Imp.MiraiBase.Message;
using Camille.Imp.MiraiBase.Message.MessageContainer;

namespace Camille.Imp.Extension;

public static class MessageChainExtension
{
    /// <summary>
    /// 将该消息链 发送到指定接受信息容器的目标
    /// </summary>
    /// <param name="msgContainer">群信息</param>
    /// <param name="bot"></param>
    /// <returns></returns>
    public static async Task<int> SendToAsync(this IMiraiMessageContainer msgContainer, IMiraiBot bot)
    {
        if (msgContainer is not MiraiMsgContainerBase msgContainerBase)
        {
            Shared.Logger.Warning($"[{nameof(MessageChainExtension)}]-[{nameof(SendToAsync)}]----can't send msg, unsupport msg container type: {msgContainer.GetType().FullName}.");
            return 0;
        }
        
        return msgContainerBase switch
        {
            GroupMiraiMsgContainer groupMsg => await bot.SendGroupMsg(groupMsg.Sender.Group.Id,
                msgContainer.MessageChain),
            FriendMiraiMsgContainer friendMsg => await bot.SendFriendMsg(friendMsg.Sender.Id,
                msgContainer.MessageChain),
            TempMiraiMsgContainer tempMsg => await bot.SendFriendMsg(tempMsg.Sender.Id,
                msgContainer.MessageChain),
            FriendSyncMessageContainer friendSyncMessageContainer => await UnsupportedContainer(typeof(FriendSyncMessageContainer)),
            TempSyncMessageContainer tempSyncMessageContainer => await UnsupportedContainer(typeof(TempSyncMessageContainer)),
            UnKnownContainerMsg unKnownContainerMsg => await UnsupportedContainer(typeof(UnKnownContainerMsg)),
            GroupSyncMessageContainer groupSyncMessageContainer => await UnsupportedContainer(typeof(GroupSyncMessageContainer)),
            OtherClientMiraiMsg otherClientMiraiMsg => await UnsupportedContainer(typeof(OtherClientMiraiMsg)),
            StrangerMiraiMsgContainer strangerMiraiMsgContainer => await UnsupportedContainer(typeof(StrangerMiraiMsgContainer)),
            StrangerSyncMessageContainer strangerSyncMessageContainer => await UnsupportedContainer(typeof(StrangerSyncMessageContainer)),
        };

        Task<int> UnsupportedContainer(Type type)
        {
            Shared.Logger.Warning($"[{nameof(MessageChainExtension)}]-[{nameof(SendToAsync)}]----can't send msg, unsupport msg container type: {type.FullName}.");
            return Task.FromResult(0);
        }
    }
}