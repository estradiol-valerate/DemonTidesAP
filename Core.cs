using Il2CppFabraz;
using MelonLoader;

[assembly: MelonInfo(typeof(DemonTidesAP.Core), "DemonTidesAP", "0.0.1", "estradiol-valerate", null)]
[assembly: MelonGame("Fabraz", "Demon Tides")]

namespace DemonTidesAP
{
    public class Core : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("Initialized.");
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            LoggerInstance.Msg("Scene " + sceneName + " has been initialized.");
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "World")
            {
                // This is here temporarily for debugging purposes.
            }
        }
    }
}