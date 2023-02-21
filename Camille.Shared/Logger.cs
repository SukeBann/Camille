using Camille.Logger.Config;
using ILogger = Camille.Logger.ILogger;

namespace Camille.Shared;

public static class Logger
{
    /// <summary>
    /// 具体的日志实现
    /// </summary>
    private static ILogger LoggerImp { get; set; }

    public static void InitLogger(LogConfig logConfig)
    {
        LoggerImp = new Camille.Logger.Logger();
        LoggerImp.InitLogger(logConfig);
    }

    public static void ShowLog()
    {
        throw new NotImplementedException();
    }

    public static void HiddenLog()
    {
        throw new NotImplementedException();
    }

    public static void Info(string message)
    {
        LoggerImp.Info(message);
    }

    public static void Warning(string message)
    {
        LoggerImp.Warning(message);
    }

    public static void Warning(string message, object data)
    {
        LoggerImp.Warning(message, data);
    }

    public static void Error(string message)
    {
        LoggerImp.Error(message);
    }

    public static void Error(string message, Exception? exception)
    {
        LoggerImp.Error(message, exception);
    }

    public static void Debug(string message)
    {
        LoggerImp.Debug(message);
    }

    public static void Debug<T>(string message, T obj)
    {
        LoggerImp.Debug(message, obj);
    }
}