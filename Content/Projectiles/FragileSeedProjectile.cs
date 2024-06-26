using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles
{
    public class FragileSeedProjectile : ModProjectile
    {
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

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                if (Main.rand.NextBool(3))
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Projectile.velocity * 0, ModContent.ProjectileType<FragileSeedSegment>(), (int)(Projectile.damage / 4), 0, Main.myPlayer);
                }
                if (Main.rand.NextBool(4))
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Projectile.velocity * 0, ModContent.ProjectileType<FragileSeedSegment>(), (int)(Projectile.damage / 3), 0, Main.myPlayer);
                }
                if (Main.rand.NextBool(5))
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Projectile.velocity * 0, ModContent.ProjectileType<FragileSeedSegment>(), (int)(Projectile.damage / 2), 0, Main.myPlayer);
                }
                if (Main.rand.NextBool(5))
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), target.Center, Projectile.velocity * 0, ModContent.ProjectileType<FragileSeedSegment>(), (int)(Projectile.damage / 1), 0, Main.myPlayer);
                }
            }
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

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}