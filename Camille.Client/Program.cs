using System.Threading.Channels;
using Camille.Core.Enum.MiraiBaseEnum;
using Camille.Imp.MiraiBase;using Camille.Imp.MiraiBase.Models;

var miraiEventTypeMapping = MiraiDataReflection.MiraiEventTypeMapping;
var miraiReceiveMsgTypeMapping = MiraiDataReflection.MiraiReceiveMsgTypeMapping;
var miraiBasicMsgTypeMapping = MiraiDataReflection.MiraiBasicMsgTypeMapping;

Console.WriteLine();