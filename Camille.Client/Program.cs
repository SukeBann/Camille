using System.Threading.Channels;
using Camille.Imp.MiraiBase;

Console.WriteLine("");

var miraiEventTypeMapping = MiraiDataReflection.MiraiEventTypeMapping;
foreach (var value in miraiEventTypeMapping.Values)
{
    Console.WriteLine($"{value.MiraiTypeName} -- {value.InstanceType}");
}