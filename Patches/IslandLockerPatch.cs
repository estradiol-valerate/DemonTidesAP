using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(LevelLoadZone), "OnTriggerEnter")]
public static class IslandLockerPatch
{
    public static bool Prefix(ref LevelLoadZone __instance)
    {
        return !IslandLockingHelper.IsLockedFromID(__instance.levelName) || (!Core.Connected && !Core.Debug);
    }
}