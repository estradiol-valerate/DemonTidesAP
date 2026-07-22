using Archipelago.MultiClient.Net;
using Archipelago.MultiClient.Net.Enums;
using Archipelago.MultiClient.Net.Models;
using Archipelago.MultiClient.Net.Helpers;
using DemonTidesAP.Helpers;
using Il2CppFabraz;
using Il2CppFabraz.CharacterController;
using Il2CppFabraz.Input;
using Il2CppFabraz.MovingPlatforms;
using Il2CppFabraz.SaveData;
using Il2CppFabraz.UI;
using MelonLoader;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.SceneManagement;
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

        public static ArchipelagoSession session;
        public static Instance Logger;
        public static string GameName = "Demon Tides";
        public static string PlayerName;
        public static Dictionary<long, ScoutedItemInfo> ScoutedItems;
        public static List<string> GearShown;
        public static List<string> GearCollected;

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
            Logger = LoggerInstance;
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (Debug)
            {
                LoggerInstance.Msg("Scene " + sceneName + " has been initialized.");
            }
            
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
            UnlockItem unlock = new UnlockItem();

            ItemData itemData = platformManager.GetItem(id);
            unlock.data = itemData;
            unlock.Unlock();

            CurrentSave.randomizerDictionary[id] = DisplayItemID;
        }

        public static void GiveAPItem(string ItemName)
        {
            if (ItemIDHelper.NamestoItems.ContainsKey(ItemName))
            {
                GiveItem(ItemIDHelper.NamestoItems[ItemName]);
            } else
            {
                switch (ItemName)
                {
                    case var _ when BatHelper.name == ItemName:
                        BatHelper.BatJumps = 1;
                        BeebzCharacterController.jumping.maxBatJumps = BatHelper.BatJumps;
                        break;
                    case var _ when BoostHelper.name == ItemName:
                        BoostHelper.BatBoostUnlocked = true;
                        BoostHelper.BoostUnlocked = true;
                        BoostHelper.SpinBoostUnlocked = true;
                        break;
                    case var _ when CheckpointHelper.name == ItemName:
                        CheckpointHelper.CanPlaceCheckpoint = true;
                        break;
                    case var _ when ItemArrowHelper.name == ItemName:
                        ItemArrowHelper.CanUseArrow = true;
                        break;
                    case var _ when SnakeHelper.name == ItemName:
                        SnakeHelper.SnakeUnlocked = true;
                        break;
                    case var _ when SpinHelper.name == ItemName:
                        SpinHelper.SpinUnlocked = true;
                        break;
                    case var _ when "Golden Gear" == ItemName:
                        foreach (ItemData item_data in PlatformManager.Instance.allItems)
                        {
                            if (item_data.nameContent == "Golden Gear" && !GearCollected.Contains(item_data.internalId))
                            {
                                GearCollected.Add(item_data.internalId);
                                GiveItem(item_data.internalId);
                                break;
                            }
                        }
                        break;
                    case var _ when "Talisman Slot" == ItemName:
                        foreach (ItemData item_data in PlatformManager.Instance.allItems)
                        {
                            if (item_data.nameContent == "Talisman Slot" && !GearCollected.Contains(item_data.internalId))
                            {
                                GearCollected.Add(item_data.internalId);
                                GiveItem(item_data.internalId);
                                break;
                            }
                        }
                        break;
                    case var _ when "10 Eyetems" == ItemName:
                        SaveDataManager.Instance.CurrentSaveData.CurrentEyetemCount += 10;
                        break;
                }
            }
        }

        public static void SetDisplayItem(ModelHelper model, string header_text, string footer_text)
        {
            model.SetDisplayModel();
            DisplayItem.flavorContent = header_text;
            DisplayItem.locationDescriptionContent = footer_text;
        }

        public static void OnItemReceived(ReceivedItemsHelper helper)
        {
            ItemInfo item = helper.PeekItem();

            string recieved_text = $"You Recieved: {item.ItemDisplayName}";
            Logger.Msg(recieved_text);
            GiveAPItem(item.ItemName);
            notificationQueue.PushNotification(recieved_text, $"From: {item.Player.Name}");

            helper.DequeueItem();
        }

        public static void APConnect(string server, string user, string pass)
        {
            session = ArchipelagoSessionFactory.CreateSession(server);
            // Must go BEFORE a successful connection attempt
            session.Items.ItemReceived += OnItemReceived;

            LoginResult result;

            try
            {
                // handle TryConnectAndLogin attempt here and save the returned object to `result`
                result = session.TryConnectAndLogin(GameName, user, ItemsHandlingFlags.AllItems);
            }
            catch (Exception e)
            {
                result = new LoginFailure(e.GetBaseException().Message);
            }

            if (!result.Successful)
            {
                LoginFailure failure = (LoginFailure)result;
                string errorMessage = $"Failed to Connect to {server} as {user}:";
                foreach (string error in failure.Errors)
                {
                    errorMessage += $"\n    {error}";
                }
                foreach (ConnectionRefusedError error in failure.ErrorCodes)
                {
                    errorMessage += $"\n    {error}";
                }
                
                Logger.Error(errorMessage);
                return; // Did not connect, show the user the contents of `errorMessage`
            }

            // Successfully connected, `ArchipelagoSession` (assume statically defined as `session` from now on) can now be
            // used to interact with the server and the returned `LoginSuccessful` contains some useful information about the
            // initial connection (e.g. a copy of the slot data as `loginSuccess.SlotData`)
            var loginSuccess = (LoginSuccessful)result;
            string successMessage = $"Connected Successfully to {server} as {user}";
            Logger.Msg(successMessage);
            PlayerName = user;

            foreach(ItemData item in PlatformManager.Instance.allItems)
            {
                if(item.nameContent == "Outfit")
                {
                    GiveItem(item.internalId);
                }
            }

            int length = LocationsIDHelper.NamestoIDs.Count;
            List<long> ids = new List<long>();
            foreach (string name in LocationsIDHelper.NamestoIDs.Keys)
            {
                ids.Add(session.Locations.GetLocationIdFromName(GameName, name));
            }
            MelonCoroutines.Start(ScoutLocationsInScene(ids.ToArray()));
        }

        public static void APReportCollectedLocation(params long[] ids)
        {
            session.Locations.CompleteLocationChecks(ids);
        }

        public static IEnumerator ScoutLocationsInScene(params long[] ids)
        {
            Task<Dictionary<long, ScoutedItemInfo>> task = session.Locations.ScoutLocationsAsync(HintCreationPolicy.None, ids);
            yield return new WaitUntil(new Func<bool>(() => task.IsCompleted));

            ScoutedItems = new Dictionary<long, ScoutedItemInfo>(task.Result);
        }

        public static void SetDisplayItemFromAPItem(ScoutedItemInfo iteminfo)
        {
            Logger.Msg($"You Found: {iteminfo.ItemDisplayName}");

            if (iteminfo.Player.Name == Core.PlayerName)
            {
                ItemData item = PlatformManager.Instance.GetItem(iteminfo.ItemName);
                if (item != null) 
                {
                    ModelHelper model = new ModelHelper(item);
                    Core.SetDisplayItem(model, item.flavorContent, item.locationDescriptionContent);
                } else
                {
                    switch (iteminfo.ItemName) 
                    {
                        case var _ when BatHelper.name == iteminfo.ItemName:
                            Core.SetDisplayItem(APModel, "You Found The Bat Form", "Now Get Jumpin.");
                            break;
                        case var _ when BoostHelper.name == iteminfo.ItemName:
                            Core.SetDisplayItem(APModel, "You Found Boosting", "Go Kick Some Ass.");
                            break;
                        case var _ when CheckpointHelper.name == iteminfo.ItemName:
                            Core.SetDisplayItem(APModel, "You Found The CheckPoint", "Placed A CheckPiont?"); ;
                            break;
                        case var _ when ItemArrowHelper.name == iteminfo.ItemName:
                            Core.SetDisplayItem(APModel, "You Found The Item Arrow", "Meh.");
                            break;
                        case var _ when SnakeHelper.name == iteminfo.ItemName:
                            Core.SetDisplayItem(APModel, "You Found The Snake Form", "Rolling Around At The Speed of Sound");
                            break;
                        case var _ when SpinHelper.name == iteminfo.ItemName:
                            Core.SetDisplayItem(APModel, "You Found The Spin Form", "I'm Getting Dizzy");
                            break;
                        case var _ when "goldengear" == iteminfo.ItemName:
                            foreach(ItemData item_data in PlatformManager.Instance.allItems)
                            {
                                if(item_data.nameContent == "Golden Gear" && !GearShown.Contains(item_data.internalId))
                                {
                                    GearShown.Add(item_data.internalId);
                                    ModelHelper gearmodel = new ModelHelper(item_data);
                                    Core.SetDisplayItem(gearmodel, item_data.flavorContent, item_data.locationDescriptionContent);
                                    break;
                                }
                            }
                            break;
                        case var _ when "goldengear" == iteminfo.ItemName:
                            SetDisplayItem(APModel, "You Got 10 Eyetems", "Don't Spend Them All in One Place");
                            break;
                    }
                }
                
            }
            else
            {
                Core.SetDisplayItem(Core.APModel, $"You Found: {iteminfo.ItemDisplayName}", $"For: {iteminfo.Player.Name}");
            }
        }

        
    }
}

