namespace DemonTidesAP.Helpers;

public class BoostHelper
{
    private static bool boostUnlocked;
    private static bool batBoostUnlocked;
    private static bool spinBoostUnlocked;
    public static string name = "boost";
    
    public static bool BoostUnlocked
    {
        get => boostUnlocked;
        set => boostUnlocked = value;
    }

    public static bool BatBoostUnlocked
    {
        get => batBoostUnlocked;
        set => batBoostUnlocked = value;
    }

    public static bool SpinBoostUnlocked
    {
        get => spinBoostUnlocked;
        set => spinBoostUnlocked = value;
    }
}