using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using Il2CppRotaryHeart.Lib.SerializableDictionary;

namespace DemonTidesAP.Patches.Tests;

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
                savedata.randomizerDictionary[key] = "0d90281d-ff36-4c50-8fb5-40c672da5916";
            }
            //savedata.randomizerLuciUnlocks["Lokitana"].list[0] = "1";
        }
    }
    

}