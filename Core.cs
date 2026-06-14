using DemonTidesAP.Helpers;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.Input;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(DemonTidesAP.Core), "DemonTidesAP", "0.0.1", "estradiol-valerate, RobertSPratley", null)]
[assembly: MelonGame("Fabraz", "Demon Tides")]

namespace DemonTidesAP
{
    public class Core : MelonMod
    {
        public static bool Debug = true;
        public static bool Connected;
        public static NotificationUI notificationUI;
        public static NotificationQueue notificationQueue;
        public int notif_accumulator = 1;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            if (Debug)
            {
                // This is for debug purposes, it'll eventually only be true when connected to archipelago.
                Connected = true;
                BatHelper.BatUnlocked = false;
                SpinHelper.SpinUnlocked = false;
                SnakeHelper.SnakeUnlocked = false;
                BoostHelper.BoostUnlocked = false;
                BoostHelper.BatBoostUnlocked = false;
                BoostHelper.SpinBoostUnlocked = false;
                CheckpointHelper.CanPlaceCheckpoint = false;
                ItemArrowHelper.CanUseArrow = false;

                

            }
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg("Scene " + sceneName + " has been initialized.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName is "World" or "Cutscene_1-1_Title" && Debug)
            {
                // This is here temporarily for debugging purposes.
                
                // Randomizer stuff
                //SaveData save = SaveDataManager._instance.CurrentSaveData;
                //Il2CppSystem.Collections.Generic.Dictionary<string, string> dict = save.randomizerDictionary._dict;
                
                // Custom item stuff
                //string uuid = $"ap_{Guid.NewGuid().ToString()}";
                //ItemData item = CustomItem.Create("example item", uuid, "Archipelago Item");
            }
        }

        public override void OnLateUpdate()
        {
        }

        public override void OnUpdate()
        {
            if (Input.GetKeyDown(KeyCode.J) && Debug)
            {
                MelonLogger.Msg("testing AP notification");
                notificationQueue.PushNotification($"<item name {notif_accumulator}>", $"<slot name {notif_accumulator}>");
                notif_accumulator++;
            }
        }

        
    }
}