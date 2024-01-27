using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles
{
    public class JungleOrb : ModProjectile
    {
        public override void SetStaticDefaults()
        {
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
            Projectile.timeLeft = 300;
        }

        public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.Grass, Projectile.position);

            for (int d = 0; d < 10; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleGrass, 0f, 0f, 0, default(Color), 1f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JunglePlants, 0f, 0f, 0, default(Color), 1f);
            }
        }

        public override void AI()
        {
            float maxDetectRadius = 400f;
            float projSpeed = 15f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);
            if (closestNPC == null) return;

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

        public override void Kill(int timeLeft)
        {
            for (int d = 0; d < 10; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JungleGrass, 0f, 0f, 0, default(Color), 1f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JunglePlants, 0f, 0f, 0, default(Color), 1f);
            }
        }
    }
}
