using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppSystem;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(RewardMenu), "Set")]
public static class RewardMenuSetPatch
{
    public static bool Prefix(ref RewardMenu __instance, Il2CppSystem.Action clear)
    {
        if (!Core.Connected && !Core.Debug) return true;
        clear.Invoke();
        return false;
    }
}
