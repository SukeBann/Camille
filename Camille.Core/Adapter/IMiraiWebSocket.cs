using Camille.Core.Models.MiraiWebSocket;

namespace Camille.Core.Adapter;

public interface IMiraiWebSocket
{
    public IMiraiWebSocketConnectResult CreateConnection();
}