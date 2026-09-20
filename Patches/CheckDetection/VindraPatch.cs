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

[HarmonyPatch(typeof(PostVindraSceneWrapup), "Trigger")]
public static class VindraPatch
{
    static void Postfix(PostVindraSceneWrapup __instance)
    {
        string check_name = "Vindra";
        Core.LocationDetected(check_name);
    }
}
