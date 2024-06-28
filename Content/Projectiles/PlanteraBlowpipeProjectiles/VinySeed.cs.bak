using blowpipemod.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.PlanteraBlowpipeProjectiles
{
    public class VinySeed : ModProjectile
    {
        private int oldShotTracker;
        private Vector2[] ballPositions;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;

            AIType = ProjectileID.Seed;
        }

        public override void OnSpawn(IEntitySource source)
        {
            oldShotTracker = PlanteraBlowpipe.planteraShotTracker;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];

            if (oldShotTracker == 5 && Main.myPlayer == Projectile.owner)
            {
                ballPositions = new Vector2[]
                {
                    new Vector2(0, -150),
                    new Vector2(50, -150),
                    new Vector2(-50, -150),
                    new Vector2(100, -150),
                    new Vector2(-100, -150),
                };

                for (int d = 0; d < ballPositions.Length; d++)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center + ballPositions[d], new Vector2(0, 0), ModContent.ProjectileType<VinyBall>(), Projectile.damage, 0, Main.myPlayer);
                }
            }
            if (oldShotTracker == 10 && Main.myPlayer == Projectile.owner)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), player.Center + new Vector2(0, -300), new Vector2(0, 0), ModContent.ProjectileType<VinyPlantera>(), (int)(Projectile.damage * 2), Projectile.knockBack, Main.myPlayer);
            }
            if (oldShotTracker == 15 && Main.myPlayer == Projectile.owner && PlanteraBlowpipe.vineySpinTimer <= 0)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, new Vector2(0, 0), ModContent.ProjectileType<VinySpinner>(), (int)(Projectile.damage / 3), 0, Main.myPlayer);
                PlanteraBlowpipe.vineySpinTimer = 600;
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

        public override bool PreDraw(ref Color lightColor)
        {
            Main.instance.LoadProjectile(Projectile.type);
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;

            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = (Projectile.oldPos[k] - Main.screenPosition) + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0);
            }

            return true;
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}