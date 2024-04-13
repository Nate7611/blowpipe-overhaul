using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.BlizzardBlowpipe
{
    public class IceSpike : ModProjectile
    {
        public bool spriteUpdated = false;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.light = 1f;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);

            for (int d = 0; d < 7; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default(Color), 0.8f);
            }

            Projectile.Kill();

            return false;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);

            for (int d = 0; d < 7; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default(Color), 0.8f);
            }

            Projectile.Kill();
        }

        public override void AI()
        {
            if (Projectile.ai[0] == 0)
            {
                // Get the direction towards the cursor
                Vector2 cursorPosition = Main.MouseWorld;
                Vector2 direction = cursorPosition - Projectile.Center;
                direction.Normalize();

                float rotationOffset = MathHelper.ToRadians(-90f); // Depends on your sprite, adjust this value if needed

                // Calculate the rotation angle
                Projectile.rotation = direction.ToRotation() + rotationOffset;

                // Move the projectile towards the cursor
                float speed = 20f; // Adjust this value to change the projectile speed
                Projectile.velocity = direction * speed;

                Projectile.ai[0] = 1;

                Projectile.netUpdate = true;
            }
        }
    }
}