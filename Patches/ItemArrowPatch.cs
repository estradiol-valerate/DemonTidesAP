using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.CharacterController;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(BeebzCharacterController), "TryTriggerSearchArrow")]
public static class ItemArrowPatch
{
    static bool Prefix(ref bool __result)
    {
        if (!Core.Connected || ItemArrowHelper.CanUseArrow)
        {
            return true;
        }
        
        __result = false;
        return false;
    }
}