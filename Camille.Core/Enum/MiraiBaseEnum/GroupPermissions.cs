using System.ComponentModel;
using System.Runtime.Serialization;
using Camille.Core.Attribute;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// QQ群权限
/// </summary>
public enum GroupPermissions
{
    /// <summary>
    /// 群主
    /// </summary>
    [Description("OWNER")]
    [ContentText("OWNER")]
    Owner,

    /// <summary>
    /// 管理员
    /// </summary>
    [Description("ADMINISTRATOR")]
    [ContentText("ADMINISTRATOR")]
    Administrator,

    /// <summary>
    /// 群员
    /// </summary>
    [Description("MEMBER")]
    [ContentText("MEMBER")]
    Member
}