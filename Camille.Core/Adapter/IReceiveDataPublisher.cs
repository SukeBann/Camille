using System.Reactive.Subjects;

namespace Camille.Core.Adapter;

/// <summary>
/// 将接受到的数据以string推送出去的角色定义
/// </summary>
public interface IReceiveDataPublisher
{
    /// <summary>
    /// 当接收到数据时推送消息 
    /// </summary>
    public Subject<string> OnWsReceiveMsg { get; }
}