using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using MelonLoader;
using UnityEngine;


namespace DemonTidesAP.Patches.Tests;

[HarmonyPatch(typeof(SaveDataManager), "SetCurrentSaveDataSlot")]
public static class IDPairsPatch
{
    static void Postfix(ref SaveDataManager __instance)
    {
        if (Core.Debug)
        {
            Il2CppFabraz.SaveData.SaveData save_data = __instance.CurrentSaveData;

            MelonLogger.Msg("unrando dict:");
            foreach (string key in save_data.unrandomizerDictionary._keys)
            {
                MelonLogger.Msg($"\tItemID: {key}, CheckID: {save_data.unrandomizerDictionary[key]}");
            }

            MelonLogger.Msg("rando dict:");
            foreach (string key in save_data.randomizerDictionary._keys)
            {
                MelonLogger.Msg($"\tItemID: {key}, CheckID: {save_data.unrandomizerDictionary[key]}");
            }
        }
    }
}