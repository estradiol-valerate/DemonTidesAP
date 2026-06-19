using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using Il2CppRotaryHeart.Lib.SerializableDictionary;
using MelonLoader;
using UnityEngine;


namespace DemonTidesAP.Patches;

[HarmonyPatch]
public class SaveDataGetRandomizedItem
{
    static System.Reflection.MethodBase TargetMethod()
    {
        return typeof(Il2CppFabraz.SaveData.SaveData).GetMethod("GetRandomizedItem").MakeGenericMethod(typeof(ItemData));
    }

    static bool Prefix(SaveData __instance, string id, ref ItemData itemData)
    {
        MelonLogger.Msg($"SaveData.GetRandomizedItem Called: {id}");
        string item_id = __instance.randomizerDictionary[id];
        if (item_id.Contains("6170726d"))
        {
            MelonLogger.Msg("\tAP item detected");
            itemData = new ItemData();
            itemData.internalId = item_id;
            return false;
        }
        MelonLogger.Msg("\tnormal behavior");
        return true;
    }
}

