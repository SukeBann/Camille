using Camille.Logger.Config;
using Camille.Logger.Helper;

namespace Camille.Logger;

/// <summary>
///  日志记录器的功能实现
/// </summary>
internal class Logger : ILogger
{
    /// <summary>
    /// 日志助手
    /// </summary>
    private LogHelper? LogHelper { get; set; }

    /// <summary>
    /// 显示日志窗口
    /// </summary>
    private Action? ShowLogWindow { get; set; }

    /// <summary>
    /// 隐藏日志窗口
    /// </summary>
    private Action? HiddenLogWindow { get; set; }

    public void InitLogger(LogConfig logConfig)
    {
        LogHelper = new LogHelper(logConfig);
        LogHelper.InitLog();
        LogHelper.Info("初始化日志成功!");

        ShowLogWindow = logConfig.ShowLogWindow;
        HiddenLogWindow = logConfig.HiddenLogWindow;
    }

    #region hidden or show log window

    public void ShowLog()
    {
        ShowLogWindow?.Invoke();
    }

    public void HiddenLog()
    {
        HiddenLogWindow?.Invoke();
    }

    #endregion

    #region record log

    public void Info(string message)
    {
        LogHelper?.Info(message);
    }

    public void Warning(string message)
    {
        LogHelper?.Warning(message);
    }

    public void Warning(string message, object data)
    {
        LogHelper?.Warning(message, data);
    }

    public void Error(string message)
    {
        LogHelper?.Error(message, null);
    }

    public void Error(string message, Exception? exception)
    {
        LogHelper?.Error(message, exception);
    }

    public void Debug(string message)
    {
        LogHelper?.Debug(message);
    }

    public void Debug<T>(string message, T obj)
    {
        LogHelper?.Debug(message, obj);
    }

    #endregion
}