using System.ComponentModel;

namespace Camille.Core.Enum.MiraiWebSocket;

public enum ConnectionMode
{
    [Description("")] CreateNew,

    [Description("")] Reconnect
}