using HarmonyLib;
using Il2CppFabraz.CharacterController;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(BeebzCharacterController.Water), "Initialize")]
public static class InitPatch
{
    static void Postfix(ref BeebzCharacterController.Water __instance)
    {
        if (Core.Connected)
        {
            // Speeds up swimming to make the game less annoying without snake form
            __instance.swimPaddleBurst = 50f;
        }
    }
}