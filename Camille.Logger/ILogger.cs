using System;
using Camille.Logger.Config;

namespace Camille.Logger;

/// <summary>
/// 日志模块的对外服务接口
/// </summary>
public interface ILogger
{
    /// <summary>
    /// 初始化日志模块
    /// </summary>
    /// <param name="logConfig"></param>
    public void InitLogger(LogConfig logConfig);

    #region hidden or show log window

    /// <summary>
    /// 显示日志窗口
    /// </summary>
    public void ShowLog();

    /// <summary>
    /// 隐藏日志窗口
    /// </summary>
    public void HiddenLog();

    #endregion

    #region record log

    public void Info(string message);

    public void Warning(string message);

    public void Warning(string message, object data);

    public void Error(string message);

    public void Error(string message, Exception? exception);

    public void Debug(string message);

    public void Debug<T>(string message, T obj);

    #endregion
}