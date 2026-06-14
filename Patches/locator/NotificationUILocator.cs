using DemonTidesAP.Helpers;
using HarmonyLib;
using Il2CppFabraz.UI;
using UnityEngine;
using UnityEngine.Playables;

namespace DemonTidesAP.Patches.locator;

[HarmonyPatch(typeof(NotificationUI), "Awake")]
public static class NotificationUILocator
{

    static void Postfix(NotificationUI __instance)
    {
        Core.notificationUI = __instance;
        __instance.defaultDuration = 4;
        GameObject noteGUI = __instance.gameObject;
        NotificationQueue notificationQueue = noteGUI.AddComponent<NotificationQueue>();
        Core.notificationQueue = notificationQueue;
        NotificationQueue.notificationUI = __instance;
    }
}
