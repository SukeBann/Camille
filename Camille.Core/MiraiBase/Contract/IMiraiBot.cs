using System.Reactive.Subjects;
using Camille.Core.Adapter;

namespace Camille.Core.MiraiBase;

/// <summary>
/// 单个MiraiBox实例的接口定义
/// </summary>
public interface IMiraiBot
{
    /// <summary>
    /// 机器人配置信息
    /// </summary>
    public IMiraiBotConfig MiraiBotConfig { get; init; }

    /// <summary>
    /// 开始运行Bot
    /// </summary>
    /// <returns></returns>
    public Task LinkStart();

    #region Receive

    /// <summary>
    /// 收到新的Mirai事件
    /// </summary>
    public Subject<IMiraiEvent> OnMiraiEventReceived { get; }

    /// <summary>
    /// 收到新的Mirai信息
    /// </summary>
    public Subject<IMiraiMessageContainer> OnMiraiMessageReceived { get; }

    #endregion

    #region Api Server

    /// <summary>
    /// Mirai Api请求服务
    /// </summary>
    public ICommonApiServer CommonApiServer { get; set; }

    #endregion
}