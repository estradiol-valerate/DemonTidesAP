namespace DemonTidesAP.Helpers;

public class ItemArrowHelper
{
    private static bool canUseArrow;

    public static bool CanUseArrow
    {
        get => canUseArrow;
        set => canUseArrow = value;
    }
}