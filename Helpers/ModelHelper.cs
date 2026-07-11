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

namespace DemonTidesAP.Helpers;

public class ModelHelper
{
    AssetReferenceGameObject model;
    Vector3 modelEulerOffset;
    Vector3 modelOffset;

    public ModelHelper(AssetReferenceGameObject model, Vector3 modelEulerOffset, Vector3 modelOffset) 
    {
        this.model = model;
        this.modelEulerOffset = modelEulerOffset;
        this.modelOffset = modelOffset;
    }

    public ModelHelper(ItemData item)
    {
        this.model = item.model;
        this.modelEulerOffset = item.modelEulerOffset;
        this.modelOffset = item.modelOffset;
    }

    public void SetDisplayModel()
    {
        Core.DisplayItem.model = model;
        Core.DisplayItem.modelEulerOffset = modelEulerOffset;
        Core.DisplayItem.modelOffset = modelOffset;
    }
}
