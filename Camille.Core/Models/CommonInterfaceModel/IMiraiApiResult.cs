using Camille.Core.Enum.CommonInterfaceEnum;

namespace Camille.Core.Models.CommonInterfaceModel;

/// <summary>
/// Mirai通用接口 返回结果的基础定义
/// </summary>
public interface IMiraiApiResult<T>
{
    /// <summary>
    /// 状态码
    /// </summary>
    public MiraiApiStateCode Code { get; set; }

    /// <summary>
    /// 信息
    /// </summary>
    public string Msg { get; set; }

    /// <summary>
    /// 返回数据
    /// </summary>
    public T? Data { get; set; }
}