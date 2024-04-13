using blowpipemod.Content.Projectiles.CrystalBlowpipe;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.ZenithBlowpipe
{
    public class ZenithBlowpipeProjectile : ModProjectile
    {
        public int whichCrystal;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                whichCrystal = Main.rand.Next(1, 4);
                if (whichCrystal == 1 && Main.rand.NextBool(3))
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-60, 61), Main.rand.Next(-400, -349)), Projectile.velocity * 0 + new Vector2(0, 90), ModContent.ProjectileType<CrystalBlowpipeFallingBallProjectile>(), Projectile.damage * 5, Projectile.knockBack, Main.myPlayer);
                }
                if (whichCrystal == 2)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-60, 61), Main.rand.Next(-400, -349)), Projectile.velocity * 0 + new Vector2(0, 95), ModContent.ProjectileType<CrystalBlowpipeFallingSmallProjectile>(), Projectile.damage * 5, Projectile.knockBack, Main.myPlayer);
                }
                if (whichCrystal == 3)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center + new Vector2(Main.rand.Next(-60, 61), Main.rand.Next(-400, -349)), Projectile.velocity * 0 + new Vector2(0, 100), ModContent.ProjectileType<CrystalBlowpipeFallingLargeProjectile>(), Projectile.damage * 5, Projectile.knockBack, Main.myPlayer);
                }

                if (Main.rand.NextBool(12))
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Projectile.velocity * 0, ModContent.ProjectileType<FragileSeedSegment>(), Projectile.damage / 3, 0, Main.myPlayer);
                    }
                }

            }

            if (target.lifeMax >= 6)
            {
                if (Main.rand.NextBool(20))
                {
                    Player player = Main.player[Projectile.owner];
                    player.Heal(Projectile.damage / 6);
                    for (int d = 0; d < 10; d++)
                    {
                        Dust.NewDust(target.position, target.width, target.height, DustID.LifeDrain, 0f, 0f, 0, default(Color), 1.2f);
                    }
                }
            }

            if (Main.rand.NextBool(2))
            {
                target.AddBuff(BuffID.OnFire3, 240);
            }
            if (Main.rand.NextBool(2))
            {
                target.AddBuff(BuffID.Frostburn2, 240);
            }
        }

        public override void AI()
        {
            float maxDetectRadius = 200f;
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
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}
