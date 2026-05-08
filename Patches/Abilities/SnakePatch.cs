using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.CharacterController;

namespace DemonTidesAP.Patches.Abilities;

[HarmonyPatch(typeof(BeebzCharacterController), "TrySnakeState")]
public static class SnakePatch
{
    static bool Prefix(ref bool __result)
    {
        if (!Core.Connected || SnakeHelper.SnakeUnlocked) 
            return true;
        
        __result = false;
        return false;
    }
}