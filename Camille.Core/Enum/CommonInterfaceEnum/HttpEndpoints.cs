using System.ComponentModel;
using Camille.Core.Attribute;

namespace Camille.Core.Enum.CommonInterfaceEnum;

/// <summary>
/// http请求端点
/// 从Mirai.NET搬过来的 传送门:https://github.com/SinoAHpx/Mirai.Net 
/// 我在原本的基础上做了改动
/// </summary>
public enum HttpEndpoints
{
    #region Authentication Sessions

    [Description("验证")] [ContentText("verify")]
    Verify,

    [Description("绑定")] [ContentText("bind")]
    Bind,

    [Description("获取会话信息")] [ContentText("sessionInfo")]
    SessionInfo,

    [Description("释放")] [ContentText("release")]
    Release,

    [Description("关于")] [ContentText("about")]
    About,

    [Description("获取好友列表")] [ContentText("friendList")]
    FriendList,

    #endregion

    #region Account

    [Description("删除好友")] [ContentText("deleteFriend")]
    DeleteFriend,

    #endregion

    #region Account Info

    [Description("获取群列表")] [ContentText("groupList")] [VerificationRequired]
    GroupList,

    [Description("获取群成员列表")] [ContentText("memberList")] [VerificationRequired]
    MemberList,

    [Description("获取最新群成员列表")] [ContentText("latestMemberList")] [VerificationRequired]
    LatestMemberList,

    [Description("获取Bot资料")] [ContentText("botProfile")] [VerificationRequired]
    BotProfile,

    [Description("获取好友资料")] [ContentText("friendProfile")] [VerificationRequired]
    FriendProfile,

    [Description("获取群成员资料")] [ContentText("memberProfile")] [VerificationRequired]
    MemberProfile,

    [Description("获取QQ用户资料")] [ContentText("userProfile")] [VerificationRequired]
    UserProfile,

    #endregion

    #region Message

    [Description("发送好友消息")] [ContentText("sendFriendMessage")] [VerificationRequired]
    SendFriendMessage,

    [Description("发送群消息")] [ContentText("sendGroupMessage")] [VerificationRequired]
    SendGroupMessage,

    [Description("发送临时会话消息")] [ContentText("sendTempMessage")] [VerificationRequired]
    SendTempMessage,

    [Description("发送头像戳一戳消息")] [ContentText("sendNudge")] [VerificationRequired]
    SendNudge,

    [Description("撤回消息")] [ContentText("recall")] [VerificationRequired]
    Recall,

    [Description("获取漫游消息")] [ContentText("roamingMessages")] [VerificationRequired]
    RoamingMessages,

    #endregion

    #region File

    [Description("查看文件列表")] [ContentText("file/list")]
    FileList,

    [Description("获取文件信息")] [ContentText("file/info")]
    FileInfo,

    [Description("创建文件夹")] [ContentText("file/mkdir")]
    FileCreate,

    [Description("删除文件")] [ContentText("file/delete")]
    FileDelete,

    [Description("移动文件")] [ContentText("file/move")]
    FileMove,

    [Description("重命名文件")] [ContentText("file/rename")]
    FileRename,

    [Description("图片文件上传")] [ContentText("uploadImage")]
    UploadImage,

    [Description("语音文件上传")] [ContentText("uploadVoice")]
    UploadVoice,

    [Description("群文件上传")] [ContentText("file/upload")]
    FileUpload,

    #endregion

    #region Group

    [Description("禁言群成员")] [ContentText("mute")]
    Mute,

    [Description("解除群成员禁言")] [ContentText("unmute")]
    Unmute,

    [Description("移除群成员")] [ContentText("kick")]
    Kick,

    [Description("退出群聊")] [ContentText("quit")]
    Leave,

    [Description("全体禁言")] [ContentText("muteAll")]
    MuteAll,

    [Description("解除全体禁言")] [ContentText("unmuteAll")]
    UnmuteAll,

    [Description("设置群精华消息")] [ContentText("setEssence")]
    SetEssence,

    [Description("修改群设置")] [ContentText("groupConfig")]
    GroupConfig,

    [Description("获取群员设置(Get) 修改群员设置(Post)")] [ContentText("memberInfo")]
    MemberInfo,

    [Description(" 修改群员管理员")] [ContentText("memberAdmin")]
    MemberAdmin,

    #endregion

    #region Announcement

    [Description("获取群公告")] [ContentText("anno/list")]
    GetAnnouncement,

    [Description("发布群公告")] [ContentText("anno/publish")]
    PubAnnouncement,

    [Description("删除群公告")] [ContentText("anno/delete")]
    DelAnnouncement,

    #endregion

    #region Event Response

    [Description("处理添加好友申请")] [ContentText("resp/newFriendRequestEvent")]
    NewFriendRequested,

    [Description("处理用户入群申请")] [ContentText("resp/memberJoinRequestEvent")]
    MemberJoinRequested,

    [Description("处理Bot被邀请入群申请")] [ContentText("resp/botInvitedJoinGroupRequestEvent")]
    BotInvited,

    #endregion

    #region MessageCache

    [Description("通过messageId获取消息")] [ContentText("messageFromId")] [VerificationRequired]
    MessageFromId,

    #endregion

    #region Command

    [Description("执行命令")] [ContentText("cmd/execute")]
    ExecuteCommand,

    [Description("注册命令")] [ContentText("cmd/register")]
    RegisterCommand

    #endregion
}