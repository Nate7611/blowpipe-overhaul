using IL.Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles
{
	public class GlitchedProjectile : ModProjectile
	{
		public int randomDust;
		public int spawnDust;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glitched Seed");
			ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
			ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 1;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = Main.rand.Next(-1, 3);
			Projectile.light = 1;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.extraUpdates = 1;

			AIType = ProjectileID.Seed;
		}

        public override void AI()
        {
			Projectile.netUpdate = true;

			Projectile.position = Projectile.position + new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
			Projectile.velocity = Projectile.velocity + new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));

			randomDust = Main.rand.Next(1, 10);
			spawnDust = Main.rand.Next(1, 101);

			if(randomDust == 1 && spawnDust == 1)
            {
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.VenomStaff, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 2 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 3 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Green, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 4 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.FrostDaggerfish, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 5 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonBlue, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 6 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Bone, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 7 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 8 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Grubby, 0f, 0f, 0, default(Color), 1.0f);
			}
			if (randomDust == 9 && spawnDust == 1)
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JunglePlants, 0f, 0f, 0, default(Color), 1.0f);
			}

		}

        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.Kill();

			return false;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Main.instance.LoadProjectile(Projectile.type);
			Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

			Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
			for (int k = 0; k < Projectile.oldPos.Length; k++)
			{
				Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
				Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
				Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
			}

			return true;
		}

		public override void Kill(int timeLeft)
		{
			Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
			SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
		}
	}
}