using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// 事件来源类型
/// </summary>
public enum MiraiSubjectType
{
    [Description("来自好友")] Friend,

    [Description("来自群聊")] Group
}