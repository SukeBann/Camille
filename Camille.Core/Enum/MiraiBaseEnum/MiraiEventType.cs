using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// Mirai事件类型
/// https://docs.mirai.mamoe.net/mirai-api-http/api/EventType.html
/// </summary>
public enum MiraiEventType
{
   #region Bot自身事件
   
    [Description("Bot登录成功")]
    BotOnlineEvent,
    [Description("Bot主动离线")]
    BotOfflineEventActive,
    [Description("Bot被挤下线")]
    BotOfflineEventForce,
    [Description("Bot被服务器断开或因网络问题而掉线")]
    BotOfflineEventDropped,
    [Description("Bot主动重新登录")]
    BotReloginEvent,
    
   #endregion

   #region 好友事件
   
   [Description("好友输入状态改变")]
   FriendInputStatusChangedEvent,
   [Description("好友昵称变更")]
   FriendNickChangedEvent,

   #endregion

   #region 群事件 
   
   [Description("Bot在群内的权限被改变")]
   BotGroupPermissionChangeEvent,
   [Description("Bot被禁言")]
   BotMuteEvent,
   [Description("Bot被取消禁言")]
   BotUnmuteEvent,
   [Description("Bot加入了一个群")]
   BotJoinGroupEvent,
   [Description("Bot主动退出一个群")]
   BotLeaveEventActive,
   [Description("Bot被踢出一个群")]
   BotLeaveEventKick,
   [Description("Bot因群主解散群而退出群, 操作人一定是群主")]
   BotLeaveEventDisband,
   [Description("群消息被撤回")]
   GroupRecallEvent,
   [Description("好友消息被撤回")]
   FriendRecallEvent,
   [Description("戳一戳事件")]
   NudgeEvent,
   [Description("群名发生改变")]
   GroupNameChangeEvent,
   [Description("某群入群公告变更")]
   GroupEntranceAnnouncementChangeEvent,
   [Description("全员禁言")]
   GroupMuteAllEvent,
   [Description("匿名聊天")]
   GroupAllowAnonymousChatEvent,
   [Description("坦白说")]
   GroupAllowConfessTalkEvent,
   [Description("允许群员邀请好友加群")]
   GroupAllowMemberInviteEvent,
   [Description("新人入群的事件")]
   MemberJoinEvent,
   [Description("非此Bot的群成员被踢出群聊")]
   MemberLeaveEventKick,
   [Description("非此Bot的群成员主动离群")]
   MemberLeaveEventQuit,
   [Description("群名片改动")]
   MemberCardChangeEvent,
   [Description("群头衔改动(只有群主有操作权限)")]
   MemberSpecialTitleChangeEvent,
   [Description("成员权限改变的事件(该成员不是Bot)")]
   MemberPermissionChangeEvent,
   [Description("群成员被禁言事件(该成员不是Bot)")]
   MemberMuteEvent,
   [Description("群成员被解除禁言事件(该成员不是Bot)")]
   MemberUnmuteEvent,
   [Description("群员称号改变")]
   MemberHonorChangeEvent,
   
   #endregion

   #region 申请事件

   [Description("添加好友申请")]
   NewFriendRequestEvent,
   [Description("用户入群申请（Bot需要有管理员权限）")]
   MemberJoinRequestEvent,
   [Description("Bot被邀请入群申请")]
   BotInvitedJoinGroupRequestEvent,

   #endregion

   #region 其他客户端事件 
   
   [Description("其他客户端上线")]
   OtherClientOnlineEvent,
   [Description("其他客户端离线")]
   OtherClientOfflineEvent,

   #endregion

   #region 命令事件 

   [Description("命令被执行")]
   CommandExecutedEvent,

   #endregion
   
   [Description("无法解析的事件")]
   UnKnown
}