using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;


namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(BeebzCharacterController), "Awake")]
public static class OnBeebzCharacterControllerAwake
{
    static void Postfix(PlatformManager __instance)
    {
        Core.CanUpdate = true;
    }
}
