using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(RewardMenu), "Set")]
public static class RewardMenuSetPatch
{
    public static void Postfix(ref RewardMenu __instance)
    {
        //keep deleteing and remaking thos patch so im just gonna keep it for now.
    }
}
