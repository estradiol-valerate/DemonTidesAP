namespace DemonTidesAP.Helpers;

public class SpinHelper
{
    private static bool spinUnlocked;
    public static string name = "Spin Form";


    public static bool SpinUnlocked
    {
        get => spinUnlocked;
        set => spinUnlocked = value;
    }
}