using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using UnityEngine;

namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(SaveDataManager), "Awake")]
public static class SaveDataManagerLocator
{

    static void Postfix(SaveDataManager __instance)
    {
        Core.saveDataManager = __instance;
        
    }
}
