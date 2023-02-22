using System.Net;
using System.Text;
using Camille.Core.Attribute.ExtensionMethod;
using Camille.Core.Enum.MiraiWebSocket;
using Camille.Core.Models;
using Camille.Core.Models.MiraiWebSocket;
using Flurl;

namespace Camille.Imp.Models.MiraiWebSocket;

public class MiraiWebSocketConnectData : IMiraiWebSocketConnectData
{
    /// <summary>
    /// 通过现有Session连接
    /// </summary>
    /// <param name="serverAddress">连接地址</param>
    /// <param name="connectChannelType">连接通道</param>
    /// <param name="verifyKey">验证秘钥</param>
    /// <param name="sessionKey">会话秘钥</param>
    /// <param name="qq">qq</param>
    public MiraiWebSocketConnectData(AdapterServerAddress serverAddress,
        ConnectChannelType connectChannelType,
        string verifyKey,
        string sessionKey,
        long qq)
    {
        ServerAddress = serverAddress;
        ConnectChannelType = connectChannelType;
        VerifyKey = verifyKey;
        SessionKey = sessionKey;
        QQ = qq;

        ConnectionMode = ConnectionMode.Reconnect;
    }

    /// <summary>
    /// 不提供SessionKey 新建一个连接
    /// </summary>
    /// <param name="serverAddress">连接地址</param>
    /// <param name="connectChannelType">连接通道</param>
    /// <param name="verifyKey">验证秘钥</param>
    /// <param name="qq">qq</param>
    public MiraiWebSocketConnectData(AdapterServerAddress serverAddress,
        ConnectChannelType connectChannelType,
        string verifyKey,
        long qq)
    {
        ServerAddress = serverAddress;
        ConnectChannelType = connectChannelType;
        VerifyKey = verifyKey;
        QQ = qq;

        ConnectionMode = ConnectionMode.CreateNew;
    }

    public AdapterServerAddress ServerAddress { get; set; }

    public Uri WsConnectUri
    {
        get
        { var connectString = $"ws://{ServerAddress}/{ConnectChannelType.GetContentText()}"
                .SetQueryParam("qq", QQ);

            if (SessionKey is not null)
            {
                connectString.SetQueryParam("verifyKey", VerifyKey);
            }

            return connectString.ToUri();
        }
    }

    /// <summary>
    /// Http的服务地址
    /// </summary>
    public string HttpConnectUrl => $"http://{ServerAddress}";

    public ConnectionMode ConnectionMode { get; private set; }

    public ConnectChannelType ConnectChannelType { get; set; }

    public string VerifyKey { get; set; }

    public string? SessionKey { get; set; }

    public long QQ { get; set; }
}