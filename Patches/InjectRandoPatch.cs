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
    public static string[] slot_IDs = ["c07ae6d0-7fa5-4486-a987-f0877945c697", "3a38dd60-83e9-4810-b4a4-a33a11df3d6f", "f8d84de9-b4fd-4946-ac04-d2f518a8e789"];

    static void Postfix(ref TitleMenu __instance)
    {
        SaveDataManager manager = GameObject.Find("Save Data Manager").GetComponent<SaveDataManager>();
        SaveData savedata = manager.CurrentSaveData;
        if (savedata.randomizerActive && Core.Debug)
        {
            foreach(string key in savedata.randomizerDictionary._keys)
            {
                savedata.randomizerDictionary[key] = Core.DisplayItemID;
            }

            foreach(string key in slot_IDs)
            {
                if (!savedata.randomizerDictionary.ContainsKey(key))
                {
                    savedata.randomizerDictionary.Add(key, Core.DisplayItemID);
                }
            }

        }
    }
    

}