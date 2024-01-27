using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.PlanteraBlowpipeProjectiles
{
    public class VinySpinner : ModProjectile
    {
        public int vineLifespan;

        public override void SetStaticDefaults()
        {
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
            Projectile.penetrate = -1; ;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            Projectile.netUpdate = true;

            vineLifespan++;

            if (++Projectile.frameCounter >= 3)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 21;
            }

            if (Projectile.frame == 21)
            {
                Projectile.rotation += 0.30f;
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

            if (vineLifespan >= 360)
            {
                Projectile.Kill();
            }
        }
    }
}