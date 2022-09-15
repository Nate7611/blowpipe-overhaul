using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles
{
	public class MusicalBlowpipeProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Treble Clef");

			ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
		}

		public override void SetDefaults()
		{
			Projectile.width = 48;
			Projectile.height = 45;
			Projectile.aiStyle = 0;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.light = 1f;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.timeLeft = 600;
		}

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            			if (target.lifeMax >= 6)
            {
				Player player = Main.player[Projectile.owner];
				player.Heal(damage / 3);
				for (int d = 0; d < 15; d++)
				{
					Dust.NewDust(target.position, target.width, target.height, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1.2f);
				}
            }
        }

        public override void AI()
		{
			BlowpipePlayer.musicProjectileSpawned = true;

			float maxDetectRadius = 400f;
			float projSpeed = 15f;

			NPC closestNPC = FindClosestNPC(maxDetectRadius);
			if (closestNPC == null) 
			{ 
				if (Main.myPlayer == Projectile.owner)
                {
					Player player = Main.player[Projectile.owner];
					Projectile.Center = player.Center + new Vector2(0, -80);
				}

				return;
			}

			Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
			Projectile.rotation = Projectile.velocity.ToRotation();
		}

		public NPC FindClosestNPC(float maxDetectDistance)
		{
			NPC closestNPC = null;

			float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

			for (int k = 0; k < Main.maxNPCs; k++)
			{
				NPC target = Main.npc[k];
				if (target.CanBeChasedBy())
				{
					float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);

					if (sqrDistanceToTarget < sqrMaxDetectDistance)
					{
						sqrMaxDetectDistance = sqrDistanceToTarget;
						closestNPC = target;
					}
				}
			}

			return closestNPC;
		}
	}
}
