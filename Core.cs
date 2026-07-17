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

        public static ItemData DisplayItem;
        public static string DisplayItemID = "0d90281d-ff36-4c50-8fb5-40c672da5916";
        public static ModelHelper DefaultModel;
        public static ModelHelper APModel;

        public static bool CanUpdate = false;

        public static SaveDataManager saveDataManager;

        public static TalismanInformationSectionUI HexUISection;

        public static BeebzCharacterController BeebzCharacterController;

        public static bool debug_unlocked = true;

        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
            if (Debug)
            {
                // This is for debug purposes, it'll eventually only be true when connected to archipelago.
                Connected = true;
                BatHelper.BatJumps = debug_unlocked ? 1 : 0;
                SpinHelper.SpinUnlocked = debug_unlocked;
                SnakeHelper.SnakeUnlocked = debug_unlocked;
                BoostHelper.BoostUnlocked = debug_unlocked;
                BoostHelper.BatBoostUnlocked = debug_unlocked;
                BoostHelper.SpinBoostUnlocked = debug_unlocked;
                CheckpointHelper.CanPlaceCheckpoint = debug_unlocked;
                ItemArrowHelper.CanUseArrow = debug_unlocked;
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
            if (!CanUpdate || BeebzCharacterController == null) return;

            if (Input.GetKeyDown(KeyCode.J) && Debug)
            {
                MelonLogger.Msg("testing AP notification");
                notificationQueue.PushNotification($"<item name {notif_accumulator}>", $"<slot name {notif_accumulator}>");
                notif_accumulator++;
            }

            if (Input.GetKeyDown(KeyCode.K) && Debug)
            {
                debug_unlocked = !debug_unlocked;
                BatHelper.BatJumps = debug_unlocked ? 1 : 0;
                BeebzCharacterController.jumping.maxBatJumps = BatHelper.BatJumps;
                SpinHelper.SpinUnlocked = debug_unlocked;
                SnakeHelper.SnakeUnlocked = debug_unlocked;
                BoostHelper.BoostUnlocked = debug_unlocked;
                BoostHelper.BatBoostUnlocked = debug_unlocked;
                BoostHelper.SpinBoostUnlocked = debug_unlocked;
                CheckpointHelper.CanPlaceCheckpoint = debug_unlocked;
                ItemArrowHelper.CanUseArrow = debug_unlocked;
            }

            if (Input.GetKeyDown(KeyCode.L) && Debug) 
            {
                BeebzCharacterController.AddVelocity(new Vector3(0, 100, 0));
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

            if (Input.GetKeyDown(KeyCode.Z) && Debug)
            {
                BatHelper.BatJumps = 1 - BatHelper.BatJumps;
                BeebzCharacterController.jumping.maxBatJumps = BatHelper.BatJumps;
            }

            if (Input.GetKeyDown(KeyCode.X) && Debug)
            {
                SpinHelper.SpinUnlocked = !SpinHelper.SpinUnlocked;
            }

            if (Input.GetKeyDown(KeyCode.C) && Debug)
            {
                SnakeHelper.SnakeUnlocked = !SnakeHelper.SnakeUnlocked;
            }

            if (Input.GetKeyDown(KeyCode.V) && Debug)
            {
                BoostHelper.BoostUnlocked = !BoostHelper.BoostUnlocked;
                BoostHelper.BatBoostUnlocked = !BoostHelper.BatBoostUnlocked;
                BoostHelper.SpinBoostUnlocked = !BoostHelper.SpinBoostUnlocked;
            }


            if (Input.GetKeyDown(KeyCode.N) && Debug) 
            {
                foreach(string key in HexUISection.entries._keys)
                {
                    TalismanInformationUI hex = HexUISection.entries[key];
                    if (hex.fadedIn)
                    {
                        hex.FadeOut();
                    } else
                    {
                        hex.FadeIn();
                    }
                    hex.fadedIn = !hex.fadedIn;
                }

                
            }
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

