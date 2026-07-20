namespace DemonTidesAP.Helpers;

public class SnakeHelper
{
    private static bool snakeUnlocked;
    public static string name = "snake"; 

    public static bool SnakeUnlocked
    {
        get => snakeUnlocked;
        set => snakeUnlocked = value;
    }
}