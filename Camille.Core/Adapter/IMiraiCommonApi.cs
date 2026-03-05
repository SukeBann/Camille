using Camille.Core.MiraiBase.Contract;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Core.MiraiBase.Models.CommonApi;

namespace Camille.Core.Adapter;

public interface IMiraiCommonApi
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

    /// <summary>
    /// 通过messageId获取消息
    /// </summary>
    /// <typeparam name="TMsgContainer">消息容器类型</typeparam>
    /// <param name="messageId">消息ID</param>
    /// <param name="target">好友id或群id</param>
    /// <returns>消息容器对象</returns>
    Task<TMsgContainer> GetMsgById<TMsgContainer>(int messageId, long target)
        where TMsgContainer : class, IMiraiMessageContainer;

    #endregion

    #region 获取账号信息

    /// <summary>
    /// 获取好友列表
    /// </summary>
    /// <returns>好友列表</returns>
    Task<List<Account>> GetFriendList();

    /// <summary>
    /// 获取群列表
    /// </summary>
    /// <returns>群列表</returns>
    Task<List<Group>> GetGroupList();

    /// <summary>
    /// 获取群成员列表
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <returns>群成员列表</returns>
    Task<List<GroupMember>> GetMemberList(long groupId);

    /// <summary>
    /// 获取最新群成员列表
    /// </summary>
    /// <param name="groupId">群号</param>
    /// <param name="memberIds">群成员账号列表，为空表示获取所有</param>
    /// <returns>群成员列表</returns>
    Task<List<GroupMember>> GetLatestMemberList(long groupId, List<long> memberIds);

    /// <summary>
    /// 获取Bot资料
    /// </summary>
    /// <returns>Bot资料</returns>
    Task<UserProfile> GetBotProfile();

    /// <summary>
    /// 获取好友资料
    /// </summary>
    /// <param name="target">好友QQ号</param>
    /// <returns>好友资料</returns>
    Task<UserProfile> GetFriendProfile(long target);

    /// <summary>
    /// 获取群成员资料
    /// </summary>
    /// <param name="target">群号</param>
    /// <param name="memberId">群成员QQ号</param>
    /// <returns>群成员资料</returns>
    Task<UserProfile> GetMemberProfile(long target, long memberId);

    /// <summary>
    /// 获取QQ用户资料
    /// </summary>
    /// <param name="target">QQ号</param>
    /// <returns>用户资料</returns>
    Task<UserProfile> GetUserProfile(long target);

    #endregion

    #region 消息发送与撤回

    /// <summary>
    /// 发送好友消息
    /// </summary>
    /// <param name="qq">好友QQ号</param>
    /// <param name="messageChain">消息链</param>
    /// <param name="quoteMsgId">引用消息ID</param>
    /// <returns>消息ID</returns>
    Task<int> SendFriendMessage(long qq, MessageChain messageChain, int? quoteMsgId = null);

    /// <summary>
    /// 发送群消息
    /// </summary>
    /// <param name="target">群号</param>
    /// <param name="messageChain">消息链</param>
    /// <param name="quoteMsgId">引用消息ID</param>
    /// <returns>消息ID</returns>
    Task<int> SendGroupMessage(long target, MessageChain messageChain, int? quoteMsgId = null);

    /// <summary>
    /// 发送临时会话消息
    /// </summary>
    /// <param name="qq">临时会话对象QQ号</param>
    /// <param name="group">临时会话群号</param>
    /// <param name="messageChain">消息链</param>
    /// <param name="quoteMsgId">引用消息ID</param>
    /// <returns>消息ID</returns>
    Task<int> SendTempMessage(long qq, long group, MessageChain messageChain, int? quoteMsgId = null);

    /// <summary>
    /// 发送头像戳一戳消息
    /// </summary>
    /// <param name="target">戳一戳的目标QQ号</param>
    /// <param name="subject">戳一戳接受主体(群号/好友QQ号)</param>
    /// <param name="kind">上下文类型: Friend, Group, Stranger</param>
    /// <returns>是否成功</returns>
    Task<bool> SendNudge(long target, long subject, string kind);

    /// <summary>
    /// 撤回消息
    /// </summary>
    /// <param name="messageId">消息ID</param>
    /// <param name="target">好友id或群id</param>
    /// <returns>是否成功</returns>
    Task<bool> RecallMessage(int messageId, long target);

    /// <summary>
    /// 获取漫游消息
    /// </summary>
    /// <param name="timeStart">起始时间(UTC+8时间戳，秒)</param>
    /// <param name="timeEnd">结束时间(UTC+8时间戳，秒)</param>
    /// <param name="target">好友id</param>
    /// <returns>消息链数组</returns>
    Task<List<MessageChain>> GetRoamingMessages(long timeStart, long timeEnd, long target);

    #endregion
}