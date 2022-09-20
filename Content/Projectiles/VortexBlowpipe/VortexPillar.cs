using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.VortexBlowpipe
{
    public class VortexPillar : ModProjectile
    {
        public bool exploding = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex orb");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            Main.projFrames[Projectile.type] = 7;
        }

        public override void SetDefaults()
        {
            Projectile.width = 50;
            Projectile.height = 50;
            Projectile.aiStyle = 0;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.timeLeft = 18000;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
        }

        public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
        {
            SoundEngine.PlaySound(SoundID.Item4, Projectile.position);
            for (int d = 0; d < 15; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Vortex, 0f, 0f, 0, default(Color), 1.2f);
            }
        }

        public override void AI()
        {
            if (++Projectile.frameCounter >= 10)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            Projectile.netUpdate = true;

            if (Main.myPlayer == Projectile.owner)
            {
                Player player = Main.player[Projectile.owner];
                Projectile.Center = player.Center + new Vector2(0, -80);

                if (Main.mouseRight && Main.mouseRightRelease && !exploding)
                {
                    exploding = true;
                    for (int i = 0; i < 30; i++)
                    {
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + new Vector2(Main.rand.Next(-30, 31), Main.rand.Next(-30, 31)), new Vector2(Main.rand.NextFloat(-1, 1), Main.rand.NextFloat(-1, 1)), ModContent.ProjectileType<GodlyVortexSeed>(), 120, 0, Main.myPlayer);
                    }
                    SoundEngine.PlaySound(SoundID.DD2_ExplosiveTrapExplode, Projectile.position);
                    Projectile.Kill();
                }
            }
        }
    }
}