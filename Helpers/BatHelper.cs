namespace DemonTidesAP.Helpers;

public class BatHelper
{
    private static bool batUnlocked;
    
    public static bool BatUnlocked
    {
        get => batUnlocked;
        set => batUnlocked = value;
    }
}