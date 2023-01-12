using Camille.Core.Enum.Mirai;
using Camille.Core.Models.MiraiApi;

namespace Camille.Imp.Models.MiraiApi;

/// <summary>
/// Mirai api返回结果的基础实现
/// </summary>
public abstract class MiraiApiResultBase<T>: IMiraiApiResult<T> where T : IMiraiApiData
{
    
    public MiraiApiStateCode Code { get; set; }
    
    public string Msg { get; set; }
    
    public T? Data { get; set; }
}