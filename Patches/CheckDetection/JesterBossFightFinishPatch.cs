using Archipelago.MultiClient.Net.Models;
using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.AI;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppRotaryHeart.Lib.SerializableDictionary;
using MelonLoader;
using UnityEngine;

namespace DemonTidesAP.Patches.CheckDetection;

[HarmonyPatch(typeof(JesterBossFightController), "FinishFight")]
public static class JesterBossFightFinishPatch
{
    public static string check_name = "Jester";

    static void Postfix(JesterBossFightController __instance)
    {
        long id = Core.session.Locations.GetLocationIdFromName(Core.GameName, check_name);
        if (id == -1) return;

        Core.APReportCollectedLocation(id);
        ScoutedItemInfo iteminfo = Core.ScoutedItems[Core.session.Locations.GetLocationIdFromName(Core.GameName, check_name)];
        Core.SetDisplayItemFromAPItem(iteminfo);
    }
}
