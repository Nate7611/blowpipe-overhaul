using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.HallowedBlowpipeProjectiles
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
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
