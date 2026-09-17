using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using DemonTidesAP.Helpers;


namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(BeebzCharacterController), "Awake")]
public static class BeebzCharacterControllerLocator
{
    static void Postfix(BeebzCharacterController __instance)
    {
        Core.BeebzCharacterController = __instance;
        BatHelper.AssertBatJumps();
        Core.CanUpdate = true;
    }
}
