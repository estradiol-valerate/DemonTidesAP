namespace DemonTidesAP.Helpers;

public class ItemArrowHelper
{
    private static bool canUseArrow;
    public static string name = "itemarrow";

    public static bool CanUseArrow
    {
        get => canUseArrow;
        set => canUseArrow = value;
    }
}