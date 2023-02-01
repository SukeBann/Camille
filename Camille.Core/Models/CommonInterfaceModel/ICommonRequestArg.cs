namespace Camille.Core.Models.CommonInterfaceModel;

/// <summary>
/// 通用接口请求参数
/// </summary>
public interface ICommonRequestArg
{
    /// <summary>
    /// 会话密钥
    /// </summary>
    public string? SessionKey { get; set; }
}