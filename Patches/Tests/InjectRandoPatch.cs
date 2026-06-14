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
    private static bool injectiontest = false;

    static void Postfix(ref TitleMenu __instance)
    {
        SaveDataManager manager = GameObject.Find("Save Data Manager").GetComponent<SaveDataManager>();
        SaveData savedata = manager.CurrentSaveData;
        if (savedata.randomizerActive && Core.Debug && injectiontest)
        {
            foreach(string key in savedata.randomizerDictionary._keys)
            {
                savedata.randomizerDictionary[key] = "11ac5032-f123-4571-b4ec-a33e583a4665";
            }
        }
    }
    

}