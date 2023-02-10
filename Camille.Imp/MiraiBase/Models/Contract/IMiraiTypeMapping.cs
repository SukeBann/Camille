namespace Camille.Imp.MiraiBase.Models.Contract;

/// <summary>
/// <see cref="Type"/> mapping of Mirai Event or Message
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMiraiTypeMapping<T>
where T : Enum
{
    /// <summary>
    /// 标识类型, 比如事件的类型， 或者是信息的类型
    /// </summary>
    T IdentityType { get; init; }

    /// <summary>
    /// 事件名称字符串
    /// </summary>
    string MiraiTypeName { get; init; }

    /// <summary>
    /// 事件的实例类型(<see cref="Type"/>)
    /// </summary>
    Type InstanceType { get; init; }
}