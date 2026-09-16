using Archipelago.MultiClient.Net.Models;
using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppRotaryHeart.Lib.SerializableDictionary;
using MelonLoader;
using UnityEngine;

namespace DemonTidesAP.Patches.CheckDetection;

[HarmonyPatch(typeof(Challenge), "CompleteChallenge")]
public static class ChallengesCompleteChallengePatch
{
    static void Postfix(Challenge __instance)
    {
        if (!LocationsIDHelper.IDstoNames.ContainsKey(__instance.uniqueID)) return;

        string check_name = LocationsIDHelper.IDstoNames[__instance.uniqueID];
        Core.LocationDetected(check_name);
    }
}

