using Camille.Core.MiraiBase.Models.BasicMessage;
using Masuit.Tools;

namespace Camille.Core.MiraiBase.Models.Base;

/// <summary>
/// 消息链内容体的实现, 我直接从Mirai.NET搬过来的, 除非我能想出来更好的实现方法 不然应该是不用改了
/// 感谢Mirai.NET https://github.com/SinoAHpx/Mirai.Net
/// </summary>
public class MessageChain : List<IMiraiBasicMessage>
{
    #region Ctor

    public MessageChain(IEnumerable<MiraiBasicMessageBase> collection) : base(collection)
    {
    }

    public MessageChain()
    {
    }

    #endregion

    #region Method

    /// <summary>
    /// 获取消息链中的纯文本消息
    /// </summary>
    /// <returns>如果没有文本消息返回空字符串</returns>
    public string GetPlainMessage()
    {
        var plain = this.OfType<Plain>().ToList();
        return !plain.Any() ? string.Empty : plain.Select(x => x.Text).Join("");
    }

    /// <summary>
    /// 获取消息链中的文本消息并且保持原有连贯性
    /// </summary>
    /// <returns>如果没有文本消息返回空列表</returns>
    public List<string> GetSeparatedPlainMessage()
    {
        var plain = this.OfType<Plain>().ToList();
        return !plain.Any() ? new List<string>() : plain.Select(x => x.Text).ToList<string>();
    }

    // TODO 将这三个方法作为扩展方法在Camille.Imp中实现
    // /// <summary>
    // /// 将该消息链 发送到指定接受信息容器的目标
    // /// </summary>
    // /// <param name="groupMiraiMsg">群信息</param>
    // /// <returns></returns>
    // public async Task<string> SendToAsync(GroupMiraiMsgContainer groupMiraiMsg)
    // {
    //     throw new NotImplementedException();
    //     // return await groupMessage.SendMessageAsync(this);
    // }
    //
    // /// <summary>
    // /// 将该消息链 发送到指定接受信息容器的目标
    // /// </summary>
    // /// <param name="friendMiraiMsg"></param>
    // /// <returns></returns>
    // public async Task<string> SendToAsync(FriendMiraiMsgContainer friendMiraiMsg)
    // {
    //     throw new NotImplementedException();
    //     // return await friendMessage.SendMessageAsync(this);
    // }
    //
    // /// <summary>
    // /// 将本消息链发送到指定接收器
    // /// </summary>
    // /// <param name="tempMiraiMsg"></param>
    // /// <returns></returns>
    // public async Task<string> SendToAsync(TempMiraiMsgContainer tempMiraiMsg)
    // {
    //     throw new NotImplementedException();
    //     // return await tempMessage.SendMessageAsync(this);
    // }

    /// <summary>
    /// 自动转换单个消息为消息链
    /// </summary>
    /// <param name="messageBase">基础消息基类</param>
    /// <returns></returns>
    public static implicit operator MessageChain(MiraiBasicMessageBase messageBase)
    {
        return new MessageChain(){messageBase};
    }

    /// <summary>
    /// 转换string为单文本消息链
    /// </summary>
    /// <param name="message">单条文本信息</param>
    /// <returns></returns>
    public static implicit operator MessageChain(string message)
    {
        return new MessageChain(){ new Plain(message) };
    }


    /// <summary>
    /// 拼接两个消息链
    /// </summary>
    /// <param name="chain1"></param>
    /// <param name="chain2"></param>
    /// <returns></returns>
    public static MessageChain operator +(MessageChain chain1, MessageChain chain2)
    {
        var chain = new MessageChain();
        chain.AddRange(chain1);
        chain.AddRange(chain2);
        return chain;
    }

    /// <summary>
    /// 拼接消息链和消息
    /// </summary>
    /// <param name="chain"></param>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static MessageChain operator +(MessageChain chain, MiraiBasicMessageBase msg)
    {
        chain.Add(msg);
        return chain;
    }

    #endregion
}