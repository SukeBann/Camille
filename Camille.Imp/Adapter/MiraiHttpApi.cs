using Camille.Core.Adapter;
using Camille.Core.Attribute.ExtensionMethod;
using Camille.Core.Enum.CommonInterfaceEnum;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.Models.Exceptions;
using Camille.Imp.Models;
using Camille.Shared.Extension;
using Flurl;
using Flurl.Http;
using Masuit.Tools;
using Masuit.Tools.Systems;
using Newtonsoft.Json;

namespace Camille.Imp.Adapter;


/// <summary>
/// 实现Mirai的通用接口
/// <br/>每个bot创建时都会构建一个自身专用接口适配器的实例,
/// <br/>但是多个bot构建多个MiraiHttp时， 并不会重复创建<see cref="HttpClient"/>,
/// <br/>因为HttpClient是由Flurl.Http内部创建并复用的.
/// <br/>这样做的目的在于将Bot的功能解耦。
/// </summary>
public class MiraiHttp : IMiraiHttp
{
    #region Properties

    /// <summary>
    /// Mirai http服务请求地址
    /// </summary>
    private AdapterConfig HttpAdress { get; set; }

    /// <summary>
    /// Mirai Http session key
    /// </summary>
    private string SessionKey { get; set; }

    #endregion

    #region Verify

    /// <summary>
    /// 获取code在框架内的枚举实现
    /// </summary>
    /// <param name="codeText">response返回的code</param>
    /// <returns></returns>
    private MiraiApiStateCode GetMiraiApiStateCode(string codeText)
    {
        var code = codeText.ToInt32(-1);
        return Enum.Parse<MiraiApiStateCode>(code.ToString());
    }

    /// <summary>
    /// 判断返回的json数据是否能反序列化, 如果能则判断stateCode是否异常， 如果异常则抛出错误
    /// </summary>
    /// <param name="result">返回的json数据</param>
    /// <param name="appendix">异常备注信息： 如果有异常, 则将该备注添加到异常信息中</param>
    /// <returns></returns>
    /// <exception cref="MiraiException"></exception>
    private string EnsureSuccess(string? result, string? appendix = null)
    {
        result = result ?? "";
        if (!result.TryGetJToken(out var jToken))
            throw new MiraiException($"返回结果异常: 文本无法被反序列化: {result}, {appendix ?? ""}",
                MiraiExceptionType.InvalidHttpResponse);

        if (!jToken.TryGetJObject(out var jObject)
            || !jObject.TryGetValue<string>("code", out var value)
            || value == "0") return result;

        var miraiApiStateCode = GetMiraiApiStateCode(value);
        var errorMsg =
            $"错误类型 {miraiApiStateCode.GetDescription()} \n{(appendix is null ? "" : "备注:" + appendix)}";
        throw new MiraiException(errorMsg, MiraiExceptionType.InvalidHttpResponse);
    }

    #endregion

    #region Post

    /// <summary>
    /// 异步使用指定的url和data Post请求目标api, 然后会分析返回数据是否正常, 如果请求出错, 则会抛出异常
    /// </summary>
    /// <param name="url">api地址</param>
    /// <param name="data">请求数据</param>
    /// <param name="withSessionKey">是否附加sessionKey, 默认为附加</param>
    /// <returns></returns>
    /// <exception cref="MiraiException"></exception>
    private async Task<string> PostJsonAsync(string url, object data, bool withSessionKey = true)
    {
        IFlurlRequest request = new FlurlRequest(url);
        if (withSessionKey)
        {
            request = request.WithHeader("Authorization", $"session {SessionKey}");
        }

        var response = await request.PostStringAsync(data.ToJsonString(new JsonSerializerSettings()
            {NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore}));

        var result = await request.GetStringAsync();

        return EnsureSuccess(result, "url={url}\r\npayload={json.ToJsonString()}");
    }

    ///<inheritdoc/>
    public async Task<string> PostJsonAsync(HttpEndpoints endpoint, object data, bool withSessionKey = true)
    {
        var url = $"http://{HttpAdress}/{endpoint.GetContentText()}";
        return await PostJsonAsync(url, data, withSessionKey);
    }

    #endregion

    #region Get
    
    /// <summary>
    /// 异步使用指定的url Get请求目标api, 然后会分析返回数据是否正常, 如果请求出错, 则会抛出异常
    /// </summary>
    /// <param name="url">api地址与Get参数</param>
    /// <param name="withSessionKey">是否附加sessionKey, 默认为附加</param>
    /// <returns></returns>
    /// <exception cref="MiraiException"></exception>
    private async Task<string> GetAsync(string url, bool withSessionKey = true)
    {
        IFlurlRequest request = new FlurlRequest(url);
        if (withSessionKey)
        {
            request = request.WithHeader("Authorization", $"session {SessionKey}");
        }
        
        var response = await request.GetStringAsync();
        return EnsureSuccess(response, $"url={url}");
    }

    ///<inheritdoc/>
    public async Task<string> GetAsync(HttpEndpoints endpoint, object? data = null, bool withSessionKey = true)
    {
        var url = $"http://{HttpAdress}/{endpoint.GetContentText()}";

        if (data != null)
            url = url.SetQueryParams(data);
        return await GetAsync(url, withSessionKey);
    }

    #endregion
}