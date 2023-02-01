using Serilog;

namespace Camille.Logger.Config;

// ReSharper disable once ClassNeverInstantiated.Global
public class LogConfig
{
    public Action<LoggerConfiguration>? LogWindowInitAction { get; }
    public Action? ShowLogWindow { get; }
    public Action? HiddenLogWindow { get; }

    public LogConfig(
        string logPath,
        int logFileRollCount,
        Action<LoggerConfiguration>? logWindowInitAction,
        Action? showLogWindow,
        Action? hiddenLogWindow)
    {
        LogWindowInitAction = logWindowInitAction;
        ShowLogWindow = showLogWindow;
        HiddenLogWindow = hiddenLogWindow;

        LogPath = logPath;
        LogFileRollCount = logFileRollCount;
    }

    /// <summary>
    /// 日志文件存储目录
    /// </summary>
    public string LogPath { get; set; }

    /// <summary>
    /// 日志文件留存的最大数量
    /// </summary>
    public int LogFileRollCount { get; set; }
}