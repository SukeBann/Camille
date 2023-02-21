using Camille.Core.Enum.MiraiBot;
using Camille.Core.MiraiBase;
using Camille.Core.Models;
using Masuit.Tools;

namespace Camille.Imp.MiraiBase;

/// <summary>
/// 构建Bot所需要的配置信息
/// 成功构建Bot后会存储当前Bot的配置信息
/// </summary>
public class MiraiBotConfig : IMiraiBotConfig
{
    public MiraiBotConfig(long qq, string verifyKey)
    {
        QQ = qq;
        VerifyKey = verifyKey;
    }

    #region Account

    /// <summary>
    /// 当前机器人的qq
    /// </summary>
    public long QQ { get; }

    /// <summary>
    /// 验证秘钥
    /// </summary>
    public string VerifyKey { get; }

    #endregion

    #region Adapter

    /// <summary>
    /// 信息接收适配器
    /// </summary>
    public ReceiveAdapterType ReceiveAdapterType { get; private set; }

    /// <summary>
    /// 信息接收适配器服务地址
    /// </summary>
    public AdapterServerAddress? ReceiveAdapterServerAddress { get; private set; }

    /// <summary>
    /// 接口调用适配器
    /// </summary>
    public ApiAdapterType ApiAdapterType { get; private set; }

    /// <summary>
    /// api调用配器服务地址
    /// </summary>
    public AdapterServerAddress? ApiAdapterServerAddress { get; private set; }

    /// <summary>
    /// 添加信息事件接收适配器
    /// </summary>
    /// <param name="receiveAdapterType">接收适配器类型</param>
    /// <param name="address">适配器服务地址</param>
    /// <returns></returns>
    public IMiraiBotConfig AddReceiveAdapter(ReceiveAdapterType receiveAdapterType, AdapterServerAddress address)
    {
        ReceiveAdapterType = receiveAdapterType;
        ReceiveAdapterServerAddress = address;
        return this;
    }

    /// <summary>
    /// 添加api调用适配器
    /// </summary>
    /// <param name="apiAdapterType">api调用适配器类型</param>
    /// <param name="address">适配器服务地址</param>
    /// <returns></returns>
    public IMiraiBotConfig AddApiAdapter(ApiAdapterType apiAdapterType, AdapterServerAddress address)
    {
        ApiAdapterType = apiAdapterType;
        ApiAdapterServerAddress = address;
        return this;
    }

    #endregion
}