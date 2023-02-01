using Camille.Core.Enum.CommonInterfaceEnum;
using Camille.Core.Models.CommonInterfaceModel;

namespace Camille.Imp.Models.CommonInterfaceModel;

/// <summary>
/// Mirai api返回结果的基础实现
/// </summary>
public class MiraiApiResult<T> : IMiraiApiResult<T>
{
    public MiraiApiStateCode Code { get; set; }

    public string Msg { get; set; }

    public T? Data { get; set; }
}