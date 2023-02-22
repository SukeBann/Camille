using Camille.Core.Enum.CommonInterfaceEnum;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.MiraiBase;
using Camille.Core.MiraiBase.Models;
using Camille.Core.MiraiBase.Models.Base;
using Camille.Core.MiraiBase.Models.CommonApi;
using Camille.Core.Models.CommonInterfaceModel;
using Camille.Core.Models.Exceptions;
using Camille.Shared.Extension;

namespace Camille.Imp.Adapter;

public partial class MiraiHttp
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
    public Task<SessionInfo> GetSessionInfo(string sessionInfo)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<IMiraiApiResult<bool>> Release(long qq)
    {
        throw new NotImplementedException();
    }

    #endregion

    #region 获取插件信息

    public Task<string> About()
    {
        throw new NotImplementedException();
    }

    public Task<List<long>> GetBotList()
    {
        throw new NotImplementedException();
    }

    #endregion

    #region 获取账号信息

    public Task<TMsgContainer> GetMsgById<TMsgContainer>() where TMsgContainer : IMiraiMessageContainer
    {
        throw new NotImplementedException();
    }

    public Task<List<Account>> GetFriendList()
    {
        throw new NotImplementedException();
    }

    public Task<List<Group>> GetGroupList()
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupMember>> GetMemberList(long groupId)
    {
        throw new NotImplementedException();
    }

    public Task<List<GroupMember>> GetLatestMemberList(long groupId, List<long> memberIds)
    {
        throw new NotImplementedException();
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

    #endregion
}