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
        long id = Core.session.Locations.GetLocationIdFromName(Core.GameName, __instance.uniqueID);
        if (id == -1) return;

        Core.APReportCollectedLocation(id);
        ScoutedItemInfo iteminfo = Core.ScoutedItems[Core.session.Locations.GetLocationIdFromName(Core.GameName, __instance.uniqueID)];
        Core.SetDisplayItemFromAPItem(iteminfo);
    }
}

