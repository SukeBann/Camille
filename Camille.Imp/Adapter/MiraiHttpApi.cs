using Camille.Core.Enum.CommonInterfaceEnum;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase.Contract;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Core.MiraiBase.Models.CommonApi;
using Camille.Core.Models.Exceptions;
using Camille.Imp.MiraiBase;
using Camille.Shared.Extension;

namespace Camille.Imp.Adapter;

public partial class MiraiCommonHttp
{
    #region 专用接口

    /// <inheritdoc/>
    public async Task<string> VerifyKey(string verifyKey)
    {
        var response = await PostJsonAsync(HttpEndpoints.Verify, new {verifyKey});
        var result = response.GetJsonValue<string>("session") ??
                     throw new MiraiException("无法获取正确的SessionKey!", MiraiExceptionType.UnKnownException);
        SessionKey = result;

        return result;
    }

    /// <inheritdoc/>
    public async Task<bool> Bind(long qq)
    {
        var result = await PostJsonAsync(HttpEndpoints.Bind, new {sessionKey = SessionKey, qq});
        return result.GetJsonValue<string>("msg") == "success";
    }

    /// <inheritdoc/>
    public async Task<SessionInfo> GetSessionInfo(string sessionInfo)
    {
        var response = await GetAsync(HttpEndpoints.SessionInfo, new {sessionKey = SessionKey});
        return response.GetJsonValue<SessionInfo>("data") ??
               throw new MiraiException("查询会话信息时发生错误, 无法反序列化会话数据",
                   MiraiExceptionType.InvalidHttpResponse);
    }

    /// <inheritdoc/>
    public async Task<bool> Release(long qq)
    {
        var result = await PostJsonAsync(HttpEndpoints.Release, new {sessionKey = SessionKey, qq});
        return result.GetJsonValue<string>("msg") == "success";
    }

    #endregion

    #region 获取插件信息

    /// <inheritdoc/>
    public Task<string> About()
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<List<long>> GetBotList()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region 获取账号信息

    /// <inheritdoc/>
    public async Task<TMsgContainer> GetMsgById<TMsgContainer>(int messageId, long target)
        where TMsgContainer : class, IMiraiMessageContainer
    {
        var result = await GetAsync(HttpEndpoints.MessageFromId, new {messageId, target});
        if (!result.TryGetJToken(out var jToken))
        {
            throw new MiraiException("通过id获取消息时发生错误, data为null",
                MiraiExceptionType.InvalidHttpResponse);
        }

        var token = jToken.SelectToken("data")?.ToString() ?? "";
        return MiraiDataReflection.GetMiraiMessageOfType(typeof(TMsgContainer),
                   token) as TMsgContainer ??
               throw new MiraiException("通过id获取消息时发生错误, data为null",
                   MiraiExceptionType.InvalidHttpResponse);
    }

    public async Task<List<Account>> GetFriendList()
    {
        var result = await GetAsync(HttpEndpoints.FriendList, new {sessionKey = SessionKey});
        return result.GetJsonValue<List<Account>>("data") ??
               throw new MiraiException("获取好友列表时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    public async Task<List<Group>> GetGroupList()
    {
        var result = await GetAsync(HttpEndpoints.GroupList, new {sessionKey = SessionKey});
        return result.GetJsonValue<List<Group>>("data") ??
               throw new MiraiException("获取群列表时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    public async Task<List<GroupMember>> GetMemberList(long groupId)
    {
        var result = await GetAsync(HttpEndpoints.MemberList, new {sessionKey = SessionKey, target = groupId});
        return result.GetJsonValue<List<GroupMember>>("data") ??
               throw new MiraiException("获取群成员列表时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    public async Task<List<GroupMember>> GetLatestMemberList(long groupId, List<long> memberIds)
    {
        var result = await PostJsonAsync(HttpEndpoints.LatestMemberList,
            new {sessionKey = SessionKey, target = groupId, memberIds});
        return result.GetJsonValue<List<GroupMember>>("data") ??
               throw new MiraiException("获取最新群成员列表时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    /// <inheritdoc/>
    public async Task<UserProfile> GetBotProfile()
    {
        var result = await GetAsync(HttpEndpoints.BotProfile, new {sessionKey = SessionKey});
        return result.GetJsonValue<UserProfile>("data") ??
               throw new MiraiException("获取Bot资料时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    /// <inheritdoc/>
    public async Task<UserProfile> GetFriendProfile(long target)
    {
        var result = await GetAsync(HttpEndpoints.FriendProfile, new {sessionKey = SessionKey, target});
        return result.GetJsonValue<UserProfile>("data") ??
               throw new MiraiException("获取好友资料时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    /// <inheritdoc/>
    public async Task<UserProfile> GetMemberProfile(long target, long memberId)
    {
        var result = await GetAsync(HttpEndpoints.MemberProfile,
            new {sessionKey = SessionKey, target, memberId});
        return result.GetJsonValue<UserProfile>("data") ??
               throw new MiraiException("获取群成员资料时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    /// <inheritdoc/>
    public async Task<UserProfile> GetUserProfile(long target)
    {
        var result = await GetAsync(HttpEndpoints.UserProfile, new {sessionKey = SessionKey, target});
        return result.GetJsonValue<UserProfile>("data") ??
               throw new MiraiException("获取用户资料时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    #endregion

    #region 消息发送与撤回

    /// <summary>
    /// 因为消息发送之后返回messageId 所以在这里共用这个方法提取
    /// </summary>
    /// <param name="endpoint"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private async Task<int> SendMessage(HttpEndpoints endpoint, object data)
    {
        if (endpoint != HttpEndpoints.SendFriendMessage
            && endpoint != HttpEndpoints.SendNudge
            && endpoint != HttpEndpoints.SendGroupMessage
            && endpoint != HttpEndpoints.SendTempMessage)
        {
            throw new ArgumentException("消息发送请求端点异常: 不支持的请求端点", nameof(endpoint));
        }

        var result = await PostJsonAsync(endpoint, data);
        return result.GetJsonValue<int>("messageId");
    }

    /// <inheritdoc/>
    public async Task<int> SendTempMessage(long qq, long group, MessageChain messageChain, int? quoteMsgId = null)
    {
        dynamic data = quoteMsgId is null
            ? new {qq, group, messageChain}
            : new {qq, group, messageChain, quote = quoteMsgId};
        return await SendMessage(HttpEndpoints.SendTempMessage, data);
    }

    /// <inheritdoc/>
    public async Task<int> SendFriendMessage(long qq, MessageChain messageChain, int? quoteMsgId = null)
    {
        dynamic data = quoteMsgId is null
            ? new {qq, messageChain}
            : new {qq, messageChain, quote = quoteMsgId};
        return await SendMessage(HttpEndpoints.SendFriendMessage, data);
    }

    /// <inheritdoc/>
    public async Task<int> SendGroupMessage(long target, MessageChain messageChain, int? quoteMsgId = null)
    {
        dynamic data = quoteMsgId is null
            ? new {target, messageChain}
            : new {target, messageChain, quote = quoteMsgId};

        return await SendMessage(HttpEndpoints.SendGroupMessage, data);
    }

    /// <inheritdoc/>
    public async Task<bool> SendNudge(long target, long subject, string kind)
    {
        var data = new {sessionKey = SessionKey, target, subject, kind};
        var result = await PostJsonAsync(HttpEndpoints.SendNudge, data);
        return result.GetJsonValue<string>("msg") == "success";
    }

    /// <inheritdoc/>
    public async Task<bool> RecallMessage(int messageId, long target)
    {
        var result = await PostJsonAsync(HttpEndpoints.Recall,
            new {sessionKey = SessionKey, messageId, target});
        return result.GetJsonValue<string>("msg") == "success";
    }

    /// <inheritdoc/>
    public async Task<List<MessageChain>> GetRoamingMessages(long timeStart, long timeEnd, long target)
    {
        var result = await PostJsonAsync(HttpEndpoints.RoamingMessages,
            new {timeStart, timeEnd, target});
        return result.GetJsonValue<List<MessageChain>>("data") ??
               throw new MiraiException("获取漫游消息时发生错误", MiraiExceptionType.InvalidHttpResponse);
    }

    #endregion
}