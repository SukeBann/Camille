using Camille.Core.MiraiBase.Contract;

namespace Camille.Imp.MiraiBase;

public static class MiraiBotFactory
{
    public static IMiraiBotConfig CreateBotConfig(long qq, string verifyKey)
    {
        return new MiraiBotConfig(qq, verifyKey);
    }

    public static IMiraiBot BuildBot(this IMiraiBotConfig miraiBotConfig)
    {
        return new MiraiBot(miraiBotConfig);
    }
}