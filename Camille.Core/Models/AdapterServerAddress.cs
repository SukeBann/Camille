using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.Models.Exceptions;
using Masuit.Tools;

namespace Camille.Core.Models;

/// <summary>
/// 适配器的服务地址
/// 因为太好用所以就直接从Mirai.NET搬过来了
/// </summary>
/// <param name="Host"></param>
/// <param name="Port"></param>
public record AdapterServerAddress(string Host, string Port)
{
    /// <summary>
    /// 从string自动转换成ip:port对
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public static implicit operator AdapterServerAddress(string address)
    {
        address = address
            .TrimEnd('/')
            .Replace("http://", "")
            .Replace("https://", "");

        MiraiException GetMiraiException()
        {
            return new MiraiException($"错误的地址: {address}", MiraiExceptionType.InvalidAddress);
        }

        if (!address.Contains(':')) throw GetMiraiException();

        var split = address.Split(':');

        if (split.Length != 2) throw GetMiraiException();
        if (split.Last().ToInt32() == 0) throw GetMiraiException();

        return new AdapterServerAddress(split[0], split[1]);
    }

    /// <summary>
    /// 转换为string
    /// </summary>
    /// <param name="serverAddress"></param>
    /// <returns></returns>
    public static implicit operator string(AdapterServerAddress serverAddress)
    {
        return $"{serverAddress.Host}:{serverAddress.Port}";
    }

    /// <summary>
    /// 转换为string
    /// </summary>
    /// <param name="serverAddress"></param>
    /// <returns></returns>
    public static implicit operator Uri(AdapterServerAddress serverAddress)
    {
        return new Uri($"{serverAddress.Host}:{serverAddress.Port}");
    }

    /// <summary>
    /// this
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return this;
    }
}