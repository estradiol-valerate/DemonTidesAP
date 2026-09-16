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

[HarmonyPatch(typeof(Chest), "Open")]
public static class ChestOpenPatch
{
    static void Postfix(Chest __instance)
    {
        if (!LocationsIDHelper.IDstoNames.ContainsKey(__instance.id.getID)) return;

        string check_name = LocationsIDHelper.IDstoNames[__instance.id.getID];
        Core.LocationDetected(check_name);
    }
}
