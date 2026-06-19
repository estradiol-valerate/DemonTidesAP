using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.UI;
using UnityEngine;


namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(RewardMenu), "Awake")]
public static class RewardMenuLocator
{
    static void Postfix(RewardMenu __instance)
    {
        Core.rewardMenu = __instance;
    }
}

