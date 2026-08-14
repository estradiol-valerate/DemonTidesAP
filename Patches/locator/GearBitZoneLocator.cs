using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using DemonTidesAP.Helpers;


namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(GearBitZone), "Awake")]
public static class GearBitZoneLocator
{
    static void Postfix(GearBitZone __instance)
    {
        Core.GearBitZoneList.Add(__instance);
    }
}
