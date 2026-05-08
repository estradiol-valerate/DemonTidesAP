using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.CharacterController;

namespace DemonTidesAP.Patches.Abilities;

[HarmonyPatch(typeof(BeebzCharacterController), "TryJump")]
public static class BatPatch
{
    static void Postfix(ref BeebzCharacterController __instance, ref bool __result)
    {
        if (!Core.Connected || BatHelper.BatUnlocked)
            return;
        
        // This is sloppy, probably should look into a better way later
        if (__instance.TimeSinceGrounded!>0f && !__instance.inCoyoteTime && !__instance.InWater && !__instance.IsClimbing)
        {
            __result = false;
        }


    }
}