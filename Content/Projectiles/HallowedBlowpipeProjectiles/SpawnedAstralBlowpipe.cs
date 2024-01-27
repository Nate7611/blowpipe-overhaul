using blowpipemod.Content.Items.Weapons;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.HallowedBlowpipeProjectiles
{
    public class SpawnedAstralBlowpipe : ModProjectile
    {
        private int oldAstralCount;
        private int canShoot = 30;
        private int lifespan = 1200;

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
            oldAstralCount = HallowedBlowpipe.astralCount;

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

                if (oldAstralCount == 0)
                {
                    Projectile.Center = player.Center + new Vector2(0, -50);
                }
                if (oldAstralCount == 1)
                {
                    Projectile.Center = player.Center + new Vector2(50, 0);
                }
                if (oldAstralCount == 2)
                {
                    Projectile.Center = player.Center + new Vector2(-50, 0);
                }

                Projectile.rotation = Projectile.Center.AngleTo(Main.MouseWorld);

                if (Main.mouseLeft && canShoot <= 0 && Main.myPlayer == Projectile.owner)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.DirectionTo(Main.MouseWorld) * 15, ModContent.ProjectileType<AstralSeed>(), 60, 0, Main.myPlayer);
                    canShoot = 30;
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