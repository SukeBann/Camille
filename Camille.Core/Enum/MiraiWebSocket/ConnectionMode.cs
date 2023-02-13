using System.ComponentModel;

namespace Camille.Core.Enum.MiraiWebSocket;

public enum ConnectionMode
{
    [Description("新建连接")] CreateNew,

    [Description("使用sessionKey重连")] Reconnect
}