using Camille.Core.Enum.CommonInterfaceEnum;

namespace Camille.Core.Adapter;

/// <summary>
/// Mirai Http定义
/// </summary>
public interface IMiraiHttp
{
    /// <summary>
    /// 使用对应的端点Post请求api
    /// </summary>
    /// <param name="endpoint">api端点</param>
    /// <param name="data">请求数据</param>
    /// <param name="withSessionKey">是否附加sessionKey, 默认为附加</param>
    /// <returns></returns>
    Task<string> PostJsonAsync(HttpEndpoints endpoint, object data, bool withSessionKey = true);

    /// <summary>
    /// 使用对应的端点Get请求api
    /// </summary>
    /// <param name="endpoint">api端点</param>
    /// <param name="data">请求参数</param>
    /// <param name="withSessionKey">是否附加sessionKey, 默认为附加</param>
    /// <returns></returns>
    Task<string> GetAsync(HttpEndpoints endpoint, object? data = null, bool withSessionKey = true);
}