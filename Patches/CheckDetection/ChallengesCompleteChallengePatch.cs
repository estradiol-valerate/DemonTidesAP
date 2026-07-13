using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppRotaryHeart.Lib.SerializableDictionary;
using Il2CppFabraz;

namespace DemonTidesAP.Patches.CheckDetection;

[HarmonyPatch(typeof(Challenge), "CompleteChallenge")]
public static class ChallengesCompleteChallengePatch
{
    static void Postfix(Chest __instance)
    {
        Core.SetDisplayItem(Core.APModel, "You Found: Dream Nail", "For: Maya");
    }
}

