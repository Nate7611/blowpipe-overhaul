using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles
{
    public class GlitchedProjectile : ModProjectile
    {
        public int randomDust;
        public int spawnDust;
        public int spriteTimer;
        public int lifespan = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 1;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            Main.projFrames[Projectile.type] = 6;
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.light = 1;
            Projectile.ignoreWater = false;
            Projectile.tileCollide = true;

            AIType = ProjectileID.Seed;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Venom, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.BetsysCurse, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Bleeding, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Confused, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.CursedInferno, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Daybreak, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Frostburn, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Ichor, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.OnFire, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.BoneJavelin, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Poisoned, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.ShadowFlame, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.OnFire3, Main.rand.Next(40, 251), false);
            }
            if (Main.rand.NextBool(40))
            {
                target.AddBuff(BuffID.Frostburn2, Main.rand.Next(40, 251), false);
            }
        }

        public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
        {
            Projectile.frame = Main.rand.Next(0, 6);
        }

        public override void AI()
        {
            lifespan++;

            if (lifespan >= 600)
            {
                Projectile.Kill();
            }

            Projectile.position = Projectile.position + new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));
            Projectile.velocity = Projectile.velocity + new Vector2(Main.rand.NextFloat(-2, 2), Main.rand.NextFloat(-2, 2));

            randomDust = Main.rand.Next(1, 10);
            spawnDust = Main.rand.Next(1, 101);

            if (randomDust == 1 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.VenomStaff, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 2 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 3 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Green, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 4 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.FrostDaggerfish, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 5 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.DungeonBlue, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 6 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Bone, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 7 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 8 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Grubby, 0f, 0f, 0, default(Color), 1.0f);
            }
            if (randomDust == 9 && spawnDust == 1)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.JunglePlants, 0f, 0f, 0, default(Color), 1.0f);
            }

            spriteTimer++;

            if (spriteTimer == Main.rand.Next(15, 51))
            {
                Projectile.frame = Main.rand.Next(0, 6);
                spriteTimer = 0;
            }
        }

        public override void Kill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }
    }
}