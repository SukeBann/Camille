using System.Net;
using Camille.Core.Enum.MiraiWebSocket;

namespace Camille.Core.Models.MiraiWebSocket;

/// <summary>
/// 建立MiraiWebSocket连接的参数
/// </summary>
public interface IMiraiWebSocketConnectData
{
    #region Properties

    /// <summary>
    /// ws 端口
    /// </summary>
    public int Port { get; set; }

    /// <summary>
    /// Ip Address
    /// </summary>
    public IPAddress IpAddress { get; set; }
    
    /// <summary>
    /// Ws connect Uri
    /// </summary>
    public Uri ConnectUri { get; }
    
    /// <summary>
    /// 连接模式
    /// </summary>
    public ConnectionMode ConnectionMode { get; }
    
    /// <summary>
    /// 连接模式
    /// </summary>
    public ConnectChannelType ConnectChannelType { get; set; }
    
    /// <summary>
    /// verifyKey, 配置文件中指定 
    /// </summary>
    public string VerifyKey { get; set; }

    /// <summary>
    /// 新建连接 或 singleMode 模式下为空, 通过已有 sessionKey 连接时不可为空
    /// </summary>
    public string? SessionKey { get; set; }

    /// <summary>
    ///  绑定的账号, singleMode 模式下为空, 非 singleMode 下新建连接不可为空
    /// </summary>
    public long Qq { get; set; }

    #endregion
}