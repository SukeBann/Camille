using Camille.Imp.MiraiBase.Message;

namespace Camille.Imp.MiraiBase.Tools;

/// <summary>
/// 消息的扩展方法
/// </summary>
public static class MessageExtension
{
    /// <summary>
    /// 将基础消息转换为只包含目标基础消息的 消息链
    /// </summary>
    /// <param name="basicMsg">基础消息</param>
    /// <typeparam name="TBasicMsg">基础消息泛型类型, 必须是继承于<see cref="MiraiBasicMessageBase"/>的类型</typeparam>
    /// <returns></returns>
    public static MessageChain ToMessageChain<TBasicMsg>(this TBasicMsg basicMsg)
        where TBasicMsg : MiraiBasicMessageBase
    {
        return new MessageChain() {basicMsg};
    }
}