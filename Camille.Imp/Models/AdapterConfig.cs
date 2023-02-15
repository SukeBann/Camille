using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Core.Models.Exceptions;
using Masuit.Tools;

namespace Camille.Imp.Models;

/// <summary>
/// 适配器配置
/// 因为太好用所以就直接从Mirai.NET搬过来了
/// </summary>
/// <param name="Host"></param>
/// <param name="Port"></param>
public record AdapterConfig(string Host, string Port)
{
    /// <summary>
    /// 从string自动转换成ip:port对
    /// </summary>
    /// <param name="address"></param>
    /// <returns></returns>
    public static implicit operator AdapterConfig(string address)
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

        return new AdapterConfig(split[0], split[1]);
    }

    /// <summary>
    /// 转换为string
    /// </summary>
    /// <param name="config"></param>
    /// <returns></returns>
    public static implicit operator string(AdapterConfig config)
    {
        return $"{config.Host}:{config.Port}";
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