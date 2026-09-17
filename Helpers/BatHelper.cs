namespace DemonTidesAP.Helpers;

public class BatHelper
{
    private static int batJumps;
    public static string name = "Bat Form";
    
    public static int BatJumps
    {
        get => batJumps;
        set => batJumps = value;
    }

    public static void AssertBatJumps()
    {
        Core.BeebzCharacterController.jumping.maxBatJumps = batJumps;
        Core.BeebzCharacterController.optica.batOpticaConsumed = (batJumps == 0);
    }
}