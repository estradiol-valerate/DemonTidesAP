using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.CharacterController;

namespace DemonTidesAP.Patches.Abilities;

[HarmonyPatch(typeof(BeebzCharacterController), "TrySnakeState")]
public static class SnakePatch
{
    static bool Prefix(ref bool __result)
    {
        bool is_snake = (Core.BeebzCharacterController.GetCurrentForm() == BeebzCharacterController.FormState.Snake);
        bool in_challenge = Core.BeebzCharacterController.challenges.currentChallenge != null;
        if (!(Core.Connected && !is_snake && !SnakeHelper.SnakeUnlocked && !(Core.BeebzCharacterController.InWater && !in_challenge)))
            return true;

        __result = false;
        return false;
    }
}