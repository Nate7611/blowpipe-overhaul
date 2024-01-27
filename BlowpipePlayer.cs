using Terraria.ModLoader;

namespace blowpipemod
{
    public class BlowpipePlayer : ModPlayer
    {
        public static bool holdingFewBlowpipe;
        public static bool holdingMoreBlowpipe;
        public static bool holdingManyBlowpipe;
        public static bool blockingSeeds;
        public static bool holdingGlitchedBlowpipe;
        public static bool holdingBlizzardBlowpipe;
        public static bool musicProjectileSpawned;

        public static int blizzardCounter;

        public override void ResetEffects()
        {
            holdingManyBlowpipe = false;
            holdingMoreBlowpipe = false;
            holdingFewBlowpipe = false;
            blockingSeeds = false;
            musicProjectileSpawned = false;
            holdingGlitchedBlowpipe = false;
            holdingBlizzardBlowpipe = false;
        }
    }
}