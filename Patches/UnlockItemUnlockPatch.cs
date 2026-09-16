using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppSystem;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(UnlockItem), "Unlock")]
public static class UnlockItemUnlockPatch
{
    public static bool Prefix(ref UnlockItem __instance)
    {
        bool AP = __instance.data.locationDescriptionContent == "AP";
        bool C = Core.Connected;
        bool D = Core.Debug;

        //if this is an AP item give it, otherwise only give the item during normal non AP conditions
        return (!AP && !C && !D) || AP;
    }
}
