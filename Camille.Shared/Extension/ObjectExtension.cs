using System.Diagnostics.CodeAnalysis;

namespace Camille.Shared.Extension;

public static class ObjectExtension
{
    /// <summary>
    /// 如果目标为null则抛出异常, 否则返回目标的本身
    /// </summary>
    /// <param name="target">要检测的目标对象</param>
    /// <param name="returnValue">返回的值, 如果返回了此值则一定不为null</param>
    /// <typeparam name="T">目标泛型， 约束为class</typeparam>
    /// <exception cref="NullReferenceException">目标为Null时抛出异常</exception>
    public static void IfNullThenThrowException<T>(this T? target, [NotNullWhen(true)] out T returnValue)
        where T : class
    {
        returnValue = target ?? throw new NullReferenceException("空引用目标!");
    }
}