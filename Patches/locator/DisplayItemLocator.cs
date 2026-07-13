using HarmonyLib;
using Il2CppFabraz;
using DemonTidesAP.Helpers;
using Il2CppInterop.Runtime.InteropTypes.Arrays;


namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(PlatformManager), "Awake")]
public static class DisplayItemLocator
{
    static void Postfix(PlatformManager __instance)
    {
        Core.DisplayItem = __instance.GetItem(Core.DisplayItemID); // get default dress item
        Core.DefaultModel = new ModelHelper(__instance.GetItem(Core.DisplayItemID)); // get default dress model
        Core.APModel = new ModelHelper(__instance.GetItem("11ac5032-f123-4571-b4ec-a33e583a4665")); // get model for AP items
        
    }
}