namespace DemonTidesAP.Helpers;

public class CheckpointHelper
{
    private static bool canPlaceCheckpoint;
    public static string name = "Checkpoint";

    public static bool CanPlaceCheckpoint
    {
        get => canPlaceCheckpoint;
        set => canPlaceCheckpoint = value;
    }
}