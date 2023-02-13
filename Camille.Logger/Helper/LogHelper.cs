using Camille.Logger.Config;
using Newtonsoft.Json;
using Serilog;

namespace Camille.Logger.Helper;

/// <summary>
/// 日志助手
/// </summary>
internal class LogHelper
{
    internal LogHelper(LogConfig logConfig)
    {
        LogConfig = logConfig;
    }

    private LogConfig LogConfig { get; set; }

    private LoggerConfiguration GenerateLoggerConfig()
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var logFilePath = Path.Combine(currentDirectory, LogConfig.LogPath);

        var loggerConfiguration = new LoggerConfiguration()
            .WriteTo.File(logFilePath,
                rollingInterval: RollingInterval.Hour,
                retainedFileCountLimit: LogConfig.LogFileRollCount)
            .MinimumLevel.Information();
#if DEBUG
        loggerConfiguration.MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.Debug();
#endif

        // 调用日志窗口初始化方法
        LogConfig.LogWindowInitAction?.Invoke(loggerConfiguration);
        return loggerConfiguration;
    }

    /// <summary>
    /// 初始化日志模块
    /// </summary>
    internal void InitLog()
    {
        CreateLoggerFromConfig(GenerateLoggerConfig());
    }

    /// <summary>
    /// 使用日志配置生成 logger
    /// </summary>
    /// <param name="loggerConfiguration">日志配置</param>
    private void CreateLoggerFromConfig(LoggerConfiguration loggerConfiguration)
    {
        Log.Logger = loggerConfiguration.CreateLogger();
    }

    /// <summary>
    /// 记录Info 级别的信息
    /// </summary>
    /// <param name="message">要记录的信息</param>
    internal void Info(string message)
    {
        Log.Logger.Information(message);
    }

    /// <summary>
    /// 记录Warning
    /// </summary>
    /// <param name="message"></param>
    internal void Warning(string message)
    {
        Log.Logger.Warning(message);
    }

    /// <summary>
    /// 记录附带data的Warning
    /// </summary>
    /// <param name="message"></param>
    /// <param name="data"></param>
    internal void Warning(string message, object data)
    {
        Log.Logger.Warning(message, data);
    }

    /// <summary>
    /// 记录Error级的信息
    /// </summary>
    /// <param name="message">要记录的信息</param>
    /// <param name="exception">要记录的异常</param>
    internal void Error(string message, Exception? exception)
    {
        if (exception is null)
        {
            Log.Error(message);
        }
        else
        {
            Log.Error(exception, message);
        }
    }

    /// <summary>
    /// 记录Debug级别的信息
    /// </summary>
    /// <param name="message">要记录的信息</param>
    internal void Debug(string message)
    {
        Log.Debug(message);
    }

    internal void Debug<T>(string message, T obj)
    {
        var objJson = JsonConvert.SerializeObject(obj);
        Debug($"{message}\n{obj}");
    }
}