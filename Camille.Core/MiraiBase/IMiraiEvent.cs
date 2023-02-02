using Camille.Core.Enum.MiraiBaseEnum;

namespace Camille.Core.MiraiBase;

/// <summary>
/// Mirai事件
/// </summary>
public interface IMiraiEvent
{
    /// <summary>
    /// Mirai事件的类型
    /// </summary>
    public MiraiEventType EventType { get; set; }
}