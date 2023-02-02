using System.Net;
using System.Text;
using Camille.Core.Attribute.ExtensionMethod;
using Camille.Core.Enum.MiraiWebSocket;
using Camille.Core.Models.MiraiWebSocket;
using Flurl;

namespace Camille.Imp.Models.MiraiWebSocket;

public class MiraiWebSocketConnectData: IMiraiWebSocketConnectData
{
    /// <summary>
    /// 通过现有Session连接
    /// </summary>
    /// <param name="port">端口</param>
    /// <param name="ipAddress">ip</param>
    /// <param name="connectChannelType">连接通道</param>
    /// <param name="verifyKey">验证秘钥</param>
    /// <param name="sessionKey">会话秘钥</param>
    /// <param name="qq">qq</param>
    public MiraiWebSocketConnectData(int port,
        IPAddress ipAddress,
        ConnectChannelType connectChannelType,
        string verifyKey,
        string sessionKey,
        long qq)
    {
        Port = port;
        IpAddress = ipAddress;
        ConnectChannelType = connectChannelType;
        VerifyKey = verifyKey;
        SessionKey = sessionKey;
        QQ = qq;
        
        ConnectionMode = ConnectionMode.Reconnect;
    }

    /// <summary>
    /// 不提供SessionKey 新建一个连接
    /// </summary>
    /// <param name="port">端口</param>
    /// <param name="ipAddress">ip</param>
    /// <param name="connectChannelType">连接通道</param>
    /// <param name="verifyKey">验证秘钥</param>
    /// <param name="qq">qq</param>
    public MiraiWebSocketConnectData(int port,
        IPAddress ipAddress,
        ConnectChannelType connectChannelType,
        string verifyKey,
        long qq)
    {
        Port = port;
        IpAddress = ipAddress;
        ConnectChannelType = connectChannelType;
        VerifyKey = verifyKey;
        QQ = qq;

        ConnectionMode = ConnectionMode.CreateNew;
    }

    public int Port { get; set; }
    
    public IPAddress IpAddress { get; set; }

    public Uri ConnectUri
    {
        get
        {
            var connectString = $"ws://{IpAddress}:{Port}/{ConnectChannelType.GetContentText()}"
                .SetQueryParam("qq", QQ);

            if (SessionKey is not null)
            {
                connectString.SetQueryParam("verifyKey", VerifyKey);
            }

            return connectString.ToUri();
        }
    }

    public ConnectionMode ConnectionMode { get; private set; } 
    
    public ConnectChannelType ConnectChannelType { get; set; }
    
    public string VerifyKey { get; set; }
    
    public string? SessionKey { get; set; }
    
    public long QQ { get; set; }
}