using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using MelonLoader;
using UnityEngine;
using Il2CppRotaryHeart.Lib.SerializableDictionary;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(SaveData), "GenerateRandomizerDictionary")]
public static class InjectRandoPatch
{
    

    static void Postfix(ref SaveData __instance)
    {
        MelonLogger.Msg("GenerateRandomizerDictionary Accessed");
        bool injection_test = true;
        if (injection_test)
        {
            SerializableDictionaryBase<string, string> randomizerDictionary = __instance.randomizerDictionary;
            foreach (string key in randomizerDictionary._keys)
            {
                randomizerDictionary[key] = "b8182536-acf0-456c-b61b-4c2d8c825968";
            }
        }
    }
}