using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.PlanteraBlowpipeProjectiles
{
    public class VinyPlantera : ModProjectile
    {
        public int chargeTimer;
        public int killTimer;
        public bool hitEnemy = false;
        public bool canCharge = true;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 154;
            Projectile.height = 116;
            Projectile.aiStyle = -1;
            Projectile.hostile = false;
            Projectile.penetrate = 4;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            hitEnemy = true;
        }

        public override void AI()
        {
            chargeTimer++;

            Projectile.netUpdate = true;

            if (++Projectile.frameCounter >= 15)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            if (hitEnemy)
            {
                killTimer++;

                if (killTimer >= 60)
                {
                    Projectile.Kill();
                }
            }

            if (chargeTimer >= 120 && canCharge && Main.myPlayer == Projectile.owner)
            {
                Projectile.friendly = true;
                Projectile.velocity = (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 20f;
                SoundEngine.PlaySound(SoundID.Roar, Projectile.position);
                canCharge = false;
            }
            else if (chargeTimer <= 120 && Main.myPlayer == Projectile.owner)
            {
                Projectile.velocity = (Main.MouseWorld - Projectile.Center).SafeNormalize(Vector2.Zero) * 0.5f;
                Projectile.rotation = Projectile.Center.AngleTo(Main.MouseWorld);
                Projectile.friendly = false;
            }
            else if (chargeTimer <= 120 && Main.myPlayer != Projectile.owner)
            {
                Projectile.rotation += 0.5f;
                Projectile.friendly = false;
            }
        }

        public override void Kill(int timeLeft)
        {
            SoundEngine.PlaySound(SoundID.NPCDeath3, Projectile.position);

            for (int d = 0; d < 15; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Plantera_Pink, 0f, 0f, 0, default(Color), 1.5f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Plantera_Green, 0f, 0f, 0, default(Color), 1.5f);
            }
        }
    }
}