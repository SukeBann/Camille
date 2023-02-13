using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// 用于描述 收到Mirai发来的数据类型
/// </summary>
public enum MiraiDataType
{
    [Description("事件")] Event,

    [Description("消息")] Message,

    [Description("未知类型")] Unknown
}