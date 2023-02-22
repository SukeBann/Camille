using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;

namespace Camille.Core.Adapter;

/// <summary>
/// Mirai 通用接口定义
/// </summary>
public interface ICommonApiServer
{
    #region 插件信息

    /// <summary>
    /// 关于
    /// </summary>
    /// <returns></returns>
    public Task<string> About();

    /// <summary>
    /// 获取当前登录的所有bot账户
    /// </summary>
    /// <returns></returns>
    public Task<List<long>> GetBotList();

    #endregion

    #region 缓存操作

    public Task<TMsgContainer> GetMsgById<TMsgContainer>() where TMsgContainer : IMiraiMessageContainer;

    #endregion

    #region 获取账号信息

    /// <summary>
    /// 获取好友列表
    /// </summary>
    /// <returns></returns>
    public Task<List<Account>> GetFriendList();

    /// <summary>
    /// 获取群列表
    /// </summary>
    /// <returns></returns>
    public Task<List<Group>> GetGroupList();

    /// <summary>
    /// 获取群成员列表 
    /// </summary>
    /// <param name="groupId">群id</param>
    /// <returns></returns>
    public Task<List<GroupMember>> GetMemberList(long groupId);

    /// <summary>
    /// 获取最新群成员列表
    /// </summary>
    /// <param name="groupId">群id</param>
    /// <param name="memberIds">群成员账号, 为空表示获取所有</param>
    /// <returns></returns>
    public Task<List<GroupMember>> GetLatestMemberList(long groupId, List<long> memberIds);

    #endregion

    #region 消息发送与撤回

    /// <summary>
    /// 发送好友消息
    /// </summary>
    /// <param name="qq">可选，发送消息目标好友的QQ号</param>
    /// <param name="messageChain">消息链</param>
    /// <param name="quoteMsgId">引用一条消息的messageId进行回复, 非必选</param>
    /// <returns>发送成功时返回当前消息的标识id (MessageId)</returns>
    public Task<int> SendFriendMessage(long qq, MessageChain messageChain, int? quoteMsgId = null);

    /// <summary>
    /// 发送群消息 
    /// </summary>
    /// <param name="target">发送消息目标群的群号</param>
    /// <param name="messageChain">消息链</param>
    /// <param name="quoteMsgId">引用一条消息的messageId进行回复, 非必选</param>
    /// <returns>发送成功时返回当前消息的标识id (MessageId)</returns>
    public Task<int> SendGroupMessage(
        long target,
        MessageChain messageChain,
        int? quoteMsgId = null);

    #endregion
}