using Archipelago.MultiClient.Net.Models;
using HarmonyLib;
using Il2CppFabraz.AI;

namespace DemonTidesAP.Patches.CheckDetection;

[HarmonyPatch(typeof(BossFightController), "FinishFight")]
public static class BossFightFinishPatch
{
    static void Postfix(BossFightController __instance)
    {
        string check_name;
        string class_name = __instance.GetScriptClassName();
        switch (class_name)
        {
            case "JesterBossFightController":
                check_name = "Jester";
                break;
            case "TridentariusBossFightController":
                check_name = "Tridentarius";
                break;
            case "RocBossFightController":
                check_name = "Roc";
                break;
            case "RagnarBossFightController":
                check_name = "Ragnar";
                break;
            default:
                check_name = "test failed";
                break;
        }
        if (Core.Debug) Core.Logger.Msg($"Boss Fight: {check_name}");

        long id = Core.session.Locations.GetLocationIdFromName(Core.GameName, check_name);
        if (id == -1) return;

        Core.APReportCollectedLocation(id);
        ScoutedItemInfo iteminfo = Core.ScoutedItems[id];
        Core.SetDisplayItemFromAPItem(iteminfo);
        
    }
}
