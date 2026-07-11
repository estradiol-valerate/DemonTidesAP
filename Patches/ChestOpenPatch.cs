using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppRotaryHeart.Lib.SerializableDictionary;
using Il2CppFabraz;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(Chest), "Open")]
public static class ChestOpenPatch
{
    static void Postfix(Chest __instance)
    {
        Core.SetDisplayItem(Core.APModel, "You Found: Heart Piece", "For: Trev");
    }
}
