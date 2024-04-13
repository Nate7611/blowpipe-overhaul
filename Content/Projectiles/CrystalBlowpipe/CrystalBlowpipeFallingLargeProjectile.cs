using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.CrystalBlowpipe
{
    public class CrystalBlowpipeFallingLargeProjectile : ModProjectile
    {
        public bool spriteUpdated = false;
        public int lifeTimer = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            Main.projFrames[Projectile.type] = 3;
        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 40;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.light = 1f;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            if (spriteUpdated == false)
            {
                Projectile.frame = Main.rand.Next(0, 3);
                spriteUpdated = true;
            }

            lifeTimer++;

            if (lifeTimer >= 300f)
            {
                SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);

                if (Projectile.frame == 2)
                {
                    for (int d = 0; d < 7; d++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default(Color), 0.9f);
                    }
                }

                if (Projectile.frame == 1)
                {
                    for (int d = 0; d < 7; d++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 0, default(Color), 0.9f);
                    }
                }

                if (Projectile.frame == 0)
                {
                    for (int d = 0; d < 7; d++)
                    {
                        Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard, 0f, 0f, 0, default(Color), 0.9f);
                    }
                }

                Projectile.Kill();
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);

            if (Projectile.frame == 1)
            {
                for (int d = 0; d < 7; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default(Color), 0.9f);
                }
            }

            if (Projectile.frame == 1)
            {
                for (int d = 0; d < 7; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PinkCrystalShard, 0f, 0f, 0, default(Color), 0.9f);
                }
            }

            if (Projectile.frame == 0)
            {
                for (int d = 0; d < 7; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleCrystalShard, 0f, 0f, 0, default(Color), 0.9f);
                }
            }
        }
    }
}