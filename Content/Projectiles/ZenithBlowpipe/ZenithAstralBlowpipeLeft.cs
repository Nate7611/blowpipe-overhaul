using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.ZenithBlowpipe
{
    public class ZenithAstralBlowpipeLeft : ModProjectile
    {
        public int canShoot = 12;
        public int lifespan = 1200;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 8;
            Projectile.aiStyle = 0;
            Projectile.friendly = false;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.penetrate = 1;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
        {
            for (int d = 0; d < 15; d++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Cloud, 0f, 0f, 0, default(Color), 1.2f);
            }
        }

        public override void AI()
        {
            Projectile.netUpdate = true;

            lifespan--;

            if (Main.myPlayer == Projectile.owner)
            {
                canShoot--;

                Player player = Main.player[Projectile.owner];
                Projectile.Center = player.Center + new Vector2(50, 0);
                Projectile.rotation = Projectile.Center.AngleTo(Main.MouseWorld);

                if (Main.mouseLeft && canShoot <= 0 && Main.myPlayer == Projectile.owner)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.DirectionTo(Main.MouseWorld) * 15, ModContent.ProjectileType<ZenithAstralSeed>(), 250, 0, Main.myPlayer);
                    canShoot = 15;
                }
            }

            if (lifespan <= 0)
            {
                for (int d = 0; d < 15; d++)
                {
                    Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Cloud, 0f, 0f, 0, default(Color), 1.2f);
                }
                Projectile.Kill();
            }
        }
    }
}