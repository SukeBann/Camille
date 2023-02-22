using Camille.Core.Enum.MiraiBot;
using Camille.Core.Models;

namespace Camille.Core.MiraiBase;

public interface IMiraiBotConfig
{
    /// <summary>
    /// 当前机器人的qq
    /// </summary>
    long QQ { get; }

    /// <summary>
    /// 验证秘钥
    /// </summary>
    string VerifyKey { get; }

    /// <summary>
    /// 信息接收适配器
    /// </summary>
    ReceiveAdapterType ReceiveAdapterType { get; }

    /// <summary>
    /// 信息接收适配器服务地址
    /// </summary>
    AdapterServerAddress? ReceiveAdapterServerAddress { get; }

    /// <summary>
    /// 接口调用适配器
    /// </summary>
    ApiAdapterType ApiAdapterType { get; }

    /// <summary>
    /// api调用配器服务地址
    /// </summary>
    AdapterServerAddress? ApiAdapterServerAddress { get; }

    /// <summary>
    /// 添加信息事件接收适配器
    /// </summary>
    /// <param name="receiveAdapterType">接收适配器类型</param>
    /// <param name="address">适配器服务地址</param>
    /// <returns></returns>
    IMiraiBotConfig AddReceiveAdapter(ReceiveAdapterType receiveAdapterType, AdapterServerAddress address);

    /// <summary>
    /// 添加api调用适配器
    /// </summary>
    /// <param name="apiAdapterType">api调用适配器类型</param>
    /// <param name="address">适配器服务地址</param>
    /// <returns></returns>
    IMiraiBotConfig AddApiAdapter(ApiAdapterType apiAdapterType, AdapterServerAddress address);
}