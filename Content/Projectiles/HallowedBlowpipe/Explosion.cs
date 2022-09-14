using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.HallowedBlowpipe
{
	public class Explosion : ModProjectile
	{
		public int lifespan = 5;

		public override void SetDefaults()
		{
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.aiStyle = 1;
			Projectile.usesLocalNPCImmunity = true;
			Projectile.localNPCHitCooldown = -1;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			SoundEngine.PlaySound(SoundID.Item62, Projectile.position);
			target.immune[Projectile.owner] = 6;
		}

        public override void AI()
        {
			lifespan--;
			if (lifespan <= 0)
            {
				Projectile.Kill();
            }
        }
    }
}
