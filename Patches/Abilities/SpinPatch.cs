using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.CharacterController;

namespace DemonTidesAP.Patches.Abilities;

[HarmonyPatch(typeof(BeebzCharacterController), "TrySpin")]
public static class TrySpinPatch
{
    static bool Prefix(ref bool __result)
    {
        if (!Core.Connected || SpinHelper.SpinUnlocked)
            return true;
        
        __result = false;
        return false;
    }
}