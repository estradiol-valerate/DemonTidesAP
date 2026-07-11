using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(RewardMenu), "Exit")]
public static class RewardMenuExitPatch
{
    public static void Postfix(ref RewardMenu __instance)
    {
        Core.SetDisplayItem(Core.DefaultModel, "Default Restored", "Fool!");
    }
}