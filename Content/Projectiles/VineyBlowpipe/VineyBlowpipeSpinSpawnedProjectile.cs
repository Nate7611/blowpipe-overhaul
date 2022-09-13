using IL.Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.VineyBlowpipe
{
	public class VineyBlowpipeSpinSpawnedProjectile : ModProjectile
	{
		public int vineLifespan;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spining Vine");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
			Main.projFrames[Projectile.type] = 22;
		}

		public override void SetDefaults()
		{
			Projectile.width = 196;
			Projectile.height = 196;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.light = 1f;
			Projectile.penetrate = -1;;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;
		}

        public override void AI()
		{
			vineLifespan++;

			Projectile.netUpdate = true;

			if (++Projectile.frameCounter >= 7)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 21;
			}

			if (Projectile.frame == 21)
            {
				Projectile.rotation += 0.15f;
				Projectile.friendly = true;
			}
            else
            {
				Projectile.friendly = false;
            }

			if (Main.myPlayer == Projectile.owner)
            {
				Projectile.Center = Main.MouseWorld;
			}

			if (vineLifespan >= 720)
            {
				Projectile.Kill();
            }
		}
	}
}