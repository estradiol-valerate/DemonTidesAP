using DemonTidesAP.Helpers;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.Input;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using System.Collections.Generic;


namespace DemonTidesAP.Helpers;

[RegisterTypeInIl2Cpp]
public class NotificationQueue : MonoBehaviour
{
    public Queue<(string, string)> queue = new Queue<(string, string)>();
    public static NotificationUI notificationUI;

    public void Start()
    {
        notificationUI = GetComponentInParent<NotificationUI>();
    }

    public void Update()
    {
        if (notificationUI.timer <= 0 && queue.Count > 0)
        {
            MelonLogger.Msg($"Update: {notificationUI.timer}");
            (string, string) token = queue.Dequeue();
            APItemNotification(token.Item1, token.Item2);
        }
    }

    public void PushNotification(string item_name, string slot_name)
    {
        if (notificationUI.timer <= 0)
        {
            MelonLogger.Msg($"PushNotification: {notificationUI.timer}");
            APItemNotification(item_name, slot_name);
        } else
        {
            AddToQueue(item_name, slot_name);
        }
    }

    public void AddToQueue(string item_name, string slot_name)
    {
        queue.Enqueue((item_name, slot_name));
    }

    public void APItemNotification(string item_name, string slot_name)
    {
        NotificationUI.NotificationDisplayData disp_data = notificationUI.notificationDisplayInfos[NotificationUI.NotificationType.GhostRaceMaxTimeWarning];

        disp_data.bannerText.translation.content[8].SetContent($"You Found {item_name}");
        disp_data.bannerText.translation.content[9].SetContent($"For {slot_name}");

        NotificationUI.NotificationData default_data = new NotificationUI.NotificationData();

        notificationUI.OnTriggerNotification(NotificationUI.NotificationType.GhostRaceMaxTimeWarning, default_data);
    }
}

