using HarmonyLib;
using Il2CppFabraz.UI;

namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(TitleMenu), "OnDestroy")]

public static class TitleMenuDestroyedPatch
{
    static void Postfix(TitleMenu __instance)
    {
        Core.titleMenuActive = false;
    }
}
