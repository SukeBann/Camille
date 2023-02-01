using Camille.Core.Models.CommonInterfaceModel;

namespace Camille.Imp.Models.CommonInterfaceModel;

public class MiraiVersionData: IMiraiApiData
{
    public string Version { get; set; }
}