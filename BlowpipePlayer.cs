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
        public static bool holdingVortexBlowpipe;
        public static bool musicProjectileSpawned;
        public static bool vinySpinnerAlive;

        public override void ResetEffects()
        {
            holdingManyBlowpipe = false;
            holdingMoreBlowpipe = false;
            blockingSeeds = false;
            holdingVortexBlowpipe = false;
            musicProjectileSpawned = false;
            holdingGlitchedBlowpipe = false;
            vinySpinnerAlive = false;
        }
    }
}