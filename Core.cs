using DemonTidesAP.Helpers;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.Input;
using Il2CppFabraz.MovingPlatforms;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using static Il2CppFabraz.CharacterController.BeebzCharacterController;
using static MelonLoader.MelonLogger;

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

        public static RewardMenu rewardMenu;
        static public Action action;

        public static ItemData DisplayItem;
        public static string DisplayItemID = "0d90281d-ff36-4c50-8fb5-40c672da5916";
        public static ModelHelper DefaultModel;
        public static ModelHelper APModel;

        public static bool CanUpdate = false;

        public static SaveDataManager saveDataManager;

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

            action = new Action(RewardUIDefaultClear);
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
            if (!CanUpdate) return;
            

            GameObject beebz = GameObject.Find("Beebz (Gameplay)");
            if (beebz == null) return;

            BeebzCharacterController controller = beebz.GetComponent<BeebzCharacterController>();
            if (Input.GetKeyDown(KeyCode.J) && Debug)
            {
                MelonLogger.Msg("testing AP notification");
                notificationQueue.PushNotification($"<item name {notif_accumulator}>", $"<slot name {notif_accumulator}>");
                notif_accumulator++;
            }

            if (Input.GetKeyDown(KeyCode.K) && Debug)
            {
                BatHelper.BatUnlocked = !BatHelper.BatUnlocked;
                SpinHelper.SpinUnlocked = !SpinHelper.SpinUnlocked;
                SnakeHelper.SnakeUnlocked = !SnakeHelper.SnakeUnlocked;
                BoostHelper.BoostUnlocked = !BoostHelper.BoostUnlocked;
                BoostHelper.BatBoostUnlocked = !BoostHelper.BatBoostUnlocked;
                BoostHelper.SpinBoostUnlocked = !BoostHelper.SpinBoostUnlocked;
                CheckpointHelper.CanPlaceCheckpoint = !CheckpointHelper.CanPlaceCheckpoint;
                ItemArrowHelper.CanUseArrow = !ItemArrowHelper.CanUseArrow;
            }

            if (Input.GetKeyDown(KeyCode.L) && Debug) 
            {
                controller.AddVelocity(new Vector3(0, 100, 0));
            }

            if (Input.GetKeyDown(KeyCode.B) && Debug)
            {
                LoggerInstance.Msg("Giving Items.");
                foreach (ItemData item in PlatformManager.Instance.allItems)
                {
                    if (item.nameContent == "Golden Gear")
                    {
                        GiveItem(item.internalId);
                    }
                }
                GiveItem("b0eb2e54-23e8-4079-a89a-c01d03238487");
                GiveItem("0ebe45b0-fa09-4fb6-aef3-691c2a71de21");

            }
        }

        static void RewardUIDefaultClear()
        {
            GameObject beebz = GameObject.Find("Beebz (Gameplay)");
            BeebzCharacterController controller = beebz.GetComponent<BeebzCharacterController>();
            BeebzCharacterController.Collectables collectables = controller.collectables;
            TimeManager.timeScale = 1;
            collectables.allGearBitsCollected = false;
            collectables.goldenGearRewardSequenceActive = false;
            collectables.goldenGearRewardAnimator.SetBool("allCollected", false);
        }

        public static void GiveItem(string id)
        {
            SaveData CurrentSave = saveDataManager.CurrentSaveData;
            CurrentSave.randomizerDictionary[id] = "1";

            PlatformManager platformManager = PlatformManager.Instance;
            ItemData itemData = platformManager.GetItem(id);
            UnlockItem unlock = new UnlockItem();
            unlock.data = itemData;
            unlock.Unlock();

            CurrentSave.randomizerDictionary[id] = DisplayItemID;
        }

        public static void SetDisplayItem(ModelHelper model, string header_text, string footer_text)
        {
            model.SetDisplayModel();
            DisplayItem.flavorContent = header_text;
            DisplayItem.locationDescriptionContent = footer_text;
        }

    }
}

