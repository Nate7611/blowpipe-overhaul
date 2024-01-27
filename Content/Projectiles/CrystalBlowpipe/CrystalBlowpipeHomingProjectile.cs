using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.CrystalBlowpipe
{
    public class CrystalBlowpipeHomingProjectile : ModProjectile
    {
        public int whichProjectile;
        public bool spriteUpdated = false;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            Main.projFrames[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 6;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.light = 1f;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;

            AIType = ProjectileID.Seed;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                whichProjectile = Main.rand.Next(1, 4);
                if (whichProjectile == 1)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-60, 61), Main.rand.Next(-400, -349)), Projectile.velocity * 0 + new Vector2(0, 5), ModContent.ProjectileType<CrystalBlowpipeFallingBallProjectile>(), Projectile.damage * 5, Projectile.knockBack, Main.myPlayer);
                }
                if (whichProjectile == 2)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-60, 61), Main.rand.Next(-400, -349)), Projectile.velocity * 0 + new Vector2(0, 5), ModContent.ProjectileType<CrystalBlowpipeFallingSmallProjectile>(), Projectile.damage * 5, Projectile.knockBack, Main.myPlayer);
                }
                if (whichProjectile == 3)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-60, 61), Main.rand.Next(-400, -349)), Projectile.velocity * 0 + new Vector2(0, 5), ModContent.ProjectileType<CrystalBlowpipeFallingLargeProjectile>(), Projectile.damage * 5, Projectile.knockBack, Main.myPlayer);
                }
            }
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);

            if (Projectile.frame == 0)
            {
                for (int d = 0; d < 7; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default(Color), 0.7f);
                }
            }

            if (Projectile.frame == 1)
            {
                for (int d = 0; d < 7; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 0, default(Color), 0.7f);
                }
            }

            if (Projectile.frame == 2)
            {
                for (int d = 0; d < 7; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard, 0f, 0f, 0, default(Color), 0.7f);
                }
            }

            Projectile.Kill();

            return false;
        }

        public override void AI()
        {
            if (spriteUpdated == false)
            {
                Projectile.frame = Main.rand.Next(0, 3);
                spriteUpdated = true;
            }

            float maxDetectRadius = 100f;
            float projSpeed = 15f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null) return;

            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
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