using Archipelago.MultiClient.Net.Enums;
using MelonLoader;
using UnityEngine;

namespace DemonTidesAP
{
    public static class Preferences
    {
        public static MelonPreferences_Category categoryColor;

        public static MelonPreferences_Entry<Color> colorPlayerSelf;
        public static MelonPreferences_Entry<Color> colorPlayerOther;

        public static MelonPreferences_Entry<Color> colorItemFiller;
        public static MelonPreferences_Entry<Color> colorItemUseful;
        public static MelonPreferences_Entry<Color> colorItemProgression;
        public static MelonPreferences_Entry<Color> colorItemTrap;

        public static void Init()
        {
            categoryColor = MelonPreferences.CreateCategory("Archipelago");
            colorPlayerSelf = categoryColor.CreateEntry<Color>("colorPlayerSelf", new Color(0.93f, 0, 0.93f), "Player (You)", "The color used when an item is received from yourself.", false);
            colorPlayerOther = categoryColor.CreateEntry<Color>("colorPlayerOther", new Color(0.98f, 0.98f, 0.82f), "Player (Others)", "The color used when an item is received from someone else.", false);
            colorItemFiller = categoryColor.CreateEntry<Color>("colorItemFiller", new Color(0, 0.93f, 0.93f), "Item (Filler)", "The color used for filler items.", false);
            colorItemUseful = categoryColor.CreateEntry<Color>("colorItemUseful", new Color(0.43f, 0.55f, 0.91f), "Item (Useful)", "The color used for useful items.", false);
            colorItemProgression = categoryColor.CreateEntry<Color>("colorItemProgression", new Color(0.69f, 0.6f, 0.94f), "Item (Progression)", "The color used for progression items.", false);
            colorItemTrap = categoryColor.CreateEntry<Color>("colorItemTrap", new Color(0.98f, 0.5f, 0.45f), "Item (Trap)", "The color used for trap items.", false);
        }

        public static string ToHtmlStringRGBA(this MelonPreferences_Entry<Color> prefColor)
        {
            // ColorUtility.ToHtmlStringRGBA is stripped :(
            // gotta do it manually

            int r = (int)Math.Round(prefColor.Value.r * 255);
            int g = (int)Math.Round(prefColor.Value.g * 255);
            int b = (int)Math.Round(prefColor.Value.b * 255);
            int a = (int)Math.Round(prefColor.Value.a * 255);

            return r.ToString("X2") + g.ToString("X2") + b.ToString("X2") + a.ToString("X2");
        }

        public static string GetColorForItemFlags(ItemFlags flags)
        {
            if (flags.HasFlag(ItemFlags.Advancement)) return colorItemProgression.ToHtmlStringRGBA();
            else if (flags.HasFlag(ItemFlags.NeverExclude)) return colorItemUseful.ToHtmlStringRGBA();
            else if (flags.HasFlag(ItemFlags.Trap)) return colorItemTrap.ToHtmlStringRGBA();
            else return colorItemFiller.ToHtmlStringRGBA();
        }
    }
}
