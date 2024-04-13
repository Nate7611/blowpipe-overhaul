using Microsoft.CodeAnalysis;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Buffers.Text;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Projectiles.BlizzardBlowpipe
{
    public class Numbers : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
            Projectile.Center = new Vector2(Projectile.width / 2, Projectile.height / 2);
        }

        public override void SetDefaults()
        {
            Projectile.width = 67;
            Projectile.height = 22;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {
            Projectile.timeLeft++;

            Player player = Main.player[Projectile.owner];

            Projectile.Center = player.Center + new Vector2(-3, -30);

            Projectile.frame = BlowpipePlayer.blizzardCounter;

            if (!BlowpipePlayer.holdingBlizzardBlowpipe)
            {
                Projectile.Kill();
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            // Return Color.White to draw the projectile in pure white (ignore lighting)
            return Color.White;
        }
    }
}