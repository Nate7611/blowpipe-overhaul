using IL.Terraria.DataStructures;
using Microsoft.Xna.Framework;
using blowpipemod.Content.Projectiles.HallowedBlowpipe;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.HallowedBlowpipe
{
	public class VortexPillar : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mini Vortex Pillar");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 38;
			Projectile.height = 8;
			Projectile.aiStyle = 0;
			Projectile.friendly = false;
			Projectile.hostile = false;
			Projectile.timeLeft = 999;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 1;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.extraUpdates = 1;
		}

		public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
		{
			for (int d = 0; d < 15; d++)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Cloud, 0f, 0f, 0, default(Color), 1.2f);
			}
		}

		public override void AI()
		{
			Projectile.netUpdate = true;

			if (Main.myPlayer == Projectile.owner)
			{
				
			}
		}
	}
}