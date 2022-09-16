using blowpipemod.Common.GlobalTiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

namespace blowpipemod
{
	public class BlowpipePlayer : ModPlayer
	{
        public static bool holdingMoreBlowpipe;
        public static bool holdingManyBlowpipe;
        public static bool blockingSeeds;
        public static bool holdingHallowedBlowpipe;
        public static bool holdingGlitchedBlowpipe;
        public static bool holdingVortexBlowpipe;
        public static bool musicProjectileSpawned;

        public override void ResetEffects()
        {
            holdingManyBlowpipe = false;
            holdingMoreBlowpipe = false;
            blockingSeeds = false;
            holdingHallowedBlowpipe = false;
            holdingVortexBlowpipe = false;
            musicProjectileSpawned = false;
            holdingGlitchedBlowpipe = false;
        }
    }
}