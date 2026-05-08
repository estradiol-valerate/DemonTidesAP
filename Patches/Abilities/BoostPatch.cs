using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.CharacterController;
using MelonLoader;

namespace DemonTidesAP.Patches.Abilities;

[HarmonyPatch(typeof(BeebzCharacterController), "TryBoost")]
public static class BoostPatch
{
    static bool Prefix(ref BeebzCharacterController __instance, ref bool __result)
    {
        if (!Core.Connected)
            return true;
        
        var currentForm = __instance.GetCurrentForm();
        
        if (BoostHelper.BatBoostUnlocked && currentForm == BeebzCharacterController.FormState.Bat)
            return true;
        if (BoostHelper.SpinBoostUnlocked && currentForm == BeebzCharacterController.FormState.Spin)
            return true;
        if (SnakeHelper.SnakeUnlocked && currentForm == BeebzCharacterController.FormState.Snake)
            return true;
        if (BoostHelper.BoostUnlocked && currentForm == BeebzCharacterController.FormState.Human)
            return true;
        
        __result = false;
        return false;
    }
}