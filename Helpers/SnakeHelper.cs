namespace DemonTidesAP.Helpers;

public class SnakeHelper
{
    private static bool snakeUnlocked;

    public static bool SnakeUnlocked
    {
        get => snakeUnlocked;
        set => snakeUnlocked = value;
    }
}