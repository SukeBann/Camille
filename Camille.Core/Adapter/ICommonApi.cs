using Camille.Core.Models.CommonInterfaceModel;
using Camille.Core.Models.MiraiWebSocket;
using Masuit.Tools.Core.Validator;

namespace Camille.Core.Adapter;

/// <summary>
/// 通用接口定义
/// </summary>
public interface ICommonApi
{
    #region 获取插件信息

    /// <summary>
    /// 获取Mirai-http插件信息
    /// </summary>
    /// <returns></returns>
    public IMiraiApiResult<IMiraiApiData> AboutMiraiHttp();

    /// <summary>
    /// 获取登录账号
    /// </summary>
    /// <returns></returns>
    public IMiraiApiResult<IMiraiApiData> GetLoginQQList();

    #endregion

    #region 缓存操作

    public IMiraiApiResult<IMiraiApiData> GetMsgByMsgId(ICommonRequestArg arg);

    #endregion
}