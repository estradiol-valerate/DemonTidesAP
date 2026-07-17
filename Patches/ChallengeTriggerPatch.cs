using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(Challenge), "TriggerChallenge")]
public static class ChallengeTriggerPatch
{
    public static void Postfix(ref Challenge __instance)
    {
        if (!SnakeHelper.SnakeUnlocked)
        {
            Core.BeebzCharacterController.TransitionToState(CharacterState.Idle);
        }
    }
}
