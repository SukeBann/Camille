using Serilog;
using Camille.Logger.Config;

namespace Camille.Logger;

/// <summary>
/// Serilog 的适配器, 实现了 <see cref="ILogger"/> 接口
/// </summary>
public class SerilogAdapter : ILogger
{
    private readonly Serilog.ILogger _logger;

    public SerilogAdapter(Serilog.ILogger logger)
    {
        _logger = logger;
    }

    public void InitLogger(LogConfig logConfig)
    {
        // 已经外部初始化过了, 这里不需要实现
    }

    public void ShowLog()
    {
        // Serilog 本身不处理窗口显示逻辑, 如果有需求可以以后扩展
    }

    public void HiddenLog()
    {
        // 同上
    }

    public void Info(string message)
    {
        _logger.Information(message);
    }

    public void Warning(string message)
    {
        _logger.Warning(message);
    }

    public void Warning(string message, object data)
    {
        _logger.Warning("{Message} {@Data}", message, data);
    }

    public void Error(string message)
    {
        _logger.Error(message);
    }

    public void Error(string message, Exception? exception)
    {
        if (exception == null)
        {
            _logger.Error(message);
        }
        else
        {
            _logger.Error(exception, message);
        }
    }

    public void Debug(string message)
    {
        _logger.Debug(message);
    }

    public void Debug<T>(string message, T obj)
    {
        _logger.Debug("{Message} {@Data}", message, obj);
    }
}
