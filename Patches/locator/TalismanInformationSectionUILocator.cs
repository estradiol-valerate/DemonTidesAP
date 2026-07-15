using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.UI;
using MelonLoader;

namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(TalismanInformationSectionUI), "TalismanInformationSectionUI")]

public static class TalismanInformationSectionUILocator
{
    static void Postfix(TalismanInformationSectionUI __instance)
    {
        MelonLogger.Msg("TalismanInformationSectionUI loaded");
        if (__instance.isActiveAndEnabled)
        {
            Core.HexUISection = __instance;
        }
        
    }
}
