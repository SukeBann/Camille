using System.ComponentModel;
using Camille.Core.Attribute;

namespace Camille.Core.Enum.MiraiBaseEnum;

/// <summary>
/// 戳一戳类型
/// </summary>
public enum MiraiPokeType
{
    [Description("戳一戳")] [ContentText("Poke")]
    Poke,

    [Description("比心")] [ContentText("ShowLove")]
    ShowLove,

    [Description("点赞")] [ContentText("Like")]
    Like,

    [Description("心碎")] [ContentText("Heartbroken")]
    Heartbroken,

    [Description("666")] [ContentText("SixSixSix")]
    SixSixSix,

    [Description("放大招")] [ContentText("FangDaZhao")]
    FangDaZhao
}