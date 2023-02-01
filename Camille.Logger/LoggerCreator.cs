namespace Camille.Logger;

/// <summary>
/// 提供对外服务的日志模块
/// </summary>
public static class LoggerCreator
{
    /// <summary>
    /// 创建一个日志模块
    /// </summary>
    /// <returns></returns>
    public static ILogger CreateLogger()
    {
        return new Logger();
    }
}