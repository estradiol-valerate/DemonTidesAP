using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using DemonTidesAP.Helpers;


namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(GearBitZone), "OnDestroy")]
public static class GearBitZoneDestroyed
{
    static void Prefix(GearBitZone __instance)
    {
        for (int i = 0; i < Core.GearBitZoneList.Count; i++)
        {
            if (Core.GearBitZoneList[i] == __instance)
            {
                Core.GearBitZoneList.RemoveAt(i);
            }
        }
    }
}
