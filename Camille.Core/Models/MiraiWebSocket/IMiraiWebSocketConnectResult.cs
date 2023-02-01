using Camille.Core.Models.CommonInterfaceModel;

namespace Camille.Core.Models.MiraiWebSocket;

public interface IMiraiWebSocketConnectResult
{
    public string SyncId { get; set; }

    public IMiraiApiData Data { get; set; }
}