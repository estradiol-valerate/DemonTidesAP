using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using DemonTidesAP.Helpers;


namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(BeebzCharacterController), "Awake")]
public static class OnBeebzCharacterControllerLocator
{
    static void Postfix(BeebzCharacterController __instance)
    {
        __instance.jumping.maxBatJumps = BatHelper.BatUnlocked ? 1 : 0;
        Core.BeebzCharacterController = __instance;
        Core.CanUpdate = true;
    }
}
