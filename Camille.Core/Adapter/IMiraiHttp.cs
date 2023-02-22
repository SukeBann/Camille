using Camille.Core.Enum.CommonInterfaceEnum;
using Camille.Core.MiraiBase.Models.CommonApi;
using Camille.Core.Models.CommonInterfaceModel;

namespace Camille.Core.Adapter;

/// <summary>
/// Mirai Http定义
/// </summary>
public interface IMiraiHttp
{
    #region 专用接口

    /// <summary>
    /// 认证：使用此方法验证你的身份，并返回一个会话秘钥
    /// </summary>
    /// <param name="verifyKey"></param>
    /// <returns>返回SessionKey</returns>
    public Task<string> VerifyKey(string verifyKey);

    /// <summary>
    /// 绑定: 使用此方法校验并激活你的Session，同时将Session与一个已登录的Bot绑定
    /// </summary>
    /// <param name="qq">要绑定的qq</param>
    /// <returns>成功返回true, 失败false</returns>
    public Task<bool> Bind(long qq);

    /// <summary>
    /// 获取会话信息：使用此方法获取 session 的相关信息
    /// </summary>
    /// <returns>返回会话信息</returns>
    public Task<SessionInfo> GetSessionInfo(string sessionInfo);

    /// <summary>
    /// 释放: 使用此方式释放session及其相关资源（Bot不会被释放） 不使用的Session应当被释放，
    /// <br/>长时间（30分钟）未使用的Session将自动释放，
    /// <br/>否则Session持续保存Bot收到的消息，将会导致内存泄露(开启websocket后将不会自动释放)
    /// </summary>
    /// <param name="qq">要释放会话的qq</param>
    /// <returns>成功返回true, 失败false</returns>
    public Task<IMiraiApiResult<bool>> Release(long qq);

    #endregion
    
    /// <summary>
    /// 使用对应的端点Post请求api
    /// </summary>
    /// <param name="endpoint">api端点</param>
    /// <param name="data">请求数据</param>
    /// <returns>返回json文本数据</returns>
    Task<string> PostJsonAsync(HttpEndpoints endpoint, object data);

    /// <summary>
    /// 使用对应的端点Get请求api
    /// </summary>
    /// <param name="endpoint">api端点</param>
    /// <param name="data">请求参数</param>
    /// <returns>返回json文本数据</returns>
    Task<string> GetAsync(HttpEndpoints endpoint, object? data = null);
}