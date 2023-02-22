using Camille.Core.Enum.CommonInterfaceEnum;

namespace Camille.Core.Attribute;

/// <summary>
/// 用于标识<see cref="HttpEndpoints"/>中的请求端点是否需要SessionKey验证
/// </summary>
[AttributeUsage(AttributeTargets.Field)]
public class VerificationRequiredAttribute: System.Attribute
{
    
}