using DemonTidesAP.Helpers;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.Input;
using Il2CppFabraz.MovingPlatforms;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using UnityEngine;
using UnityEngine.AddressableAssets;
using static Il2CppFabraz.CharacterController.BeebzCharacterController;
using System.Text.Json;

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
        public static RewardMenu rewardMenu;
        public int notif_accumulator = 1;
        static public Action action;
        public static AssetReferenceGameObject asset;
        //public static Chest chest;

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
            asset = new AssetReferenceGameObject("Assets/Interactables/Interactions/Chest/RewardChest/Chest with Reward - Ruins.prefab");
            if (asset.Asset == null) asset.LoadAsset(); // could be async loaded but this is fine for now

            //chest = ((GameObject)asset.Asset).GetComponent<Chest>();
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
            GameObject beebz = GameObject.Find("Beebz (Gameplay)");
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
                GetItem("b8182536-acf0-456c-b61b-4c2d8c825968");
                GetItem("c0a20288-7c09-4d36-acdf-fb843270816b");
                GetItem("2cae2789-297c-445e-bc51-ec104a6e8aaf");
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

        public static void GetItem(string id)
        {
            Chest chest = ((GameObject)asset.Asset).GetComponent<Chest>();
            PlatformManager platformManager = PlatformManager.Instance;
            ItemData itemData = platformManager.GetItem(id);

            if (itemData != null)
            {
                chest.unlockItem.data = itemData; // default is Level_Ruins_3_RadioTowers_GoldenGear1, can be changed to any other ItemData and seems to work fine
                chest.unlockItem.Unlock(); // gives the ItemData without using the reward menu
            }
        }

    }
}