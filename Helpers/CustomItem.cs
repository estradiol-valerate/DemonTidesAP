using Il2CppFabraz;

namespace DemonTidesAP.Helpers;

public class CustomItem : ItemData
{
    public static ItemData Create(Il2CppSystem.String name, Il2CppSystem.String id, Il2CppSystem.String flavor)
    {
        // template for later
        var item = CreateInstance<ItemData>();
        item.name = name;
        item.internalId = id;
        item.flavorContent = flavor;
        item.locationDescriptionContent = flavor;
        return item;
    }
}