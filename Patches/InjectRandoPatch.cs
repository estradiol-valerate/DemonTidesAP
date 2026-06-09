using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppRotaryHeart.Lib.SerializableDictionary;

namespace DemonTidesAP.Patches;

[HarmonyPatch(typeof(TitleMenu), "StartGame")]
public static class InjectRandoPatch
{
    private static bool injectiontest = true;

    static void Postfix(ref TitleMenu __instance)
    {
        SaveDataManager manager = GameObject.Find("Save Data Manager").GetComponent<SaveDataManager>();
        SaveData savedata = manager.CurrentSaveData;
        if (savedata.randomizerActive && Core.Debug && injectiontest)
        {
            foreach(string key in savedata.randomizerDictionary._keys)
            {
                savedata.randomizerDictionary[key] = "b8182536-acf0-456c-b61b-4c2d8c825968";
            }
        }
    }
    

}