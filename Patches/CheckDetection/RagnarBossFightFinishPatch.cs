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

[HarmonyPatch(typeof(RagnarBossFightController), "FinishFight")]
public static class RagnarBossFightFinishPatch
{
    static void Postfix(RagnarBossFightController __instance)
    {
        MelonLogger.Msg($"Check ID: oh shit you beat the game, far out");
    }
}
