using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppRotaryHeart.Lib.SerializableDictionary;
using Il2CppFabraz;
using Il2CppFabraz.AI;

namespace DemonTidesAP.Patches.CheckDetection;

[HarmonyPatch(typeof(TridentariusBossFightController), "FinishFight")]
public static class TridentariusBossFightFinishPatch
{
    static void Postfix(TridentariusBossFightController __instance)
    {
        string header_text = "You Found: Broom";
        Core.SetDisplayItem(Core.APModel, header_text, "For: Tridentarius");
    }
}
