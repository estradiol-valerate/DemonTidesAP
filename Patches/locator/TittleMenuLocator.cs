using HarmonyLib;
using Il2CppFabraz.UI;

namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(TitleMenu), "Awake")]

public static class TittleMenuLocator
{
    static void Postfix(TitleMenu __instance)
    {
        Core.titleMenuActive = true;
        ConnectMenu.Setup();
    }
}
