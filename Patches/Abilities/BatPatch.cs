using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.CharacterController;

namespace DemonTidesAP.Patches.Abilities;

[HarmonyPatch(typeof(BeebzCharacterController), "TryJump")]
public static class BatPatch
{
    static void Postfix(ref BeebzCharacterController __instance)
    {
        if (!Core.Connected || BatHelper.BatUnlocked)
            return;

        __instance.jumping.maxBatJumps = 0;
    }
}

