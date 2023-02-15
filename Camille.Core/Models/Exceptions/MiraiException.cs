using Camille.Core.Enum.MiraiBaseEnum;
using Masuit.Tools.Systems;

namespace Camille.Core.Models.Exceptions;

/// <summary>
/// 与Mirai交互时引发的异常
/// 有多个异常类型<see cref="MiraiExceptionType"/>
/// </summary>
[Serializable]
public class MiraiException: Exception
{
    /// <summary>
    /// 异常类型 
    /// </summary>
    private MiraiExceptionType ExceptionType { get; set; }

    public override string Message => $"错误类型:{ExceptionType.GetDescription()}: 信息: {base.Message}"; 

    private MiraiException() { }

    public MiraiException(string? message, MiraiExceptionType exceptionType) : base(message)
    {
        ExceptionType = exceptionType;
    }

    public MiraiException(string? message, Exception? innerException, MiraiExceptionType exceptionType) : base(message, innerException)
    {
        ExceptionType = exceptionType;
    }
}