using System.ComponentModel;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// 与Mirai交互时引发的异常类型
/// </summary>
public enum MiraiExceptionType
{
    [Description("无效的服务地址")]
    InvalidAddress,
    [Description("无效的QQ号")]
    InvalidQQ,
    [Description("无效的Http响应")]
    InvalidHttpResponse,
    [Description("无效的WebSocket响应")]
    InvalidWsResponse,
    [Description("未知异常")]
    UnKnownException
}