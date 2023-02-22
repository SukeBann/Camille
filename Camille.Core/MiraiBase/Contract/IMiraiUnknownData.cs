namespace Camille.Core.MiraiBase;

/// <summary>
/// 未知Mirai数据类型
/// </summary>
public interface IMiraiUnknownData
{
    /// <summary>
    /// 原始数据文本
    /// </summary>
    public string SourceData { get; init; }
}