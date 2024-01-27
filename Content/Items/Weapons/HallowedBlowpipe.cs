using blowpipemod.Content.Projectiles.HallowedBlowpipeProjectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class HallowedBlowpipe : ModItem
    {
        public static int astralCount;
        private int summonTimer;
        private int coolDown = 1200;
        private bool usedM2 = false;
        private bool soundPlayed = false;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 12;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.damage = 92;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(gold: 4, silver: 60);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = SoundID.Item63;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.IchorDart | type == ProjectileID.CrystalDart)
            {
                damage = (int)(damage * (1.00 - .25));
            }
        }

        public override void HoldItem(Player player)
        {
            if (Main.mouseRight && summonTimer >= 900 && Main.myPlayer == player.whoAmI)
            {
                SoundEngine.PlaySound(SoundID.Item25, player.position);

                if (astralCount == 0)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<SpawnedAstralBlowpipe>(), 100, 0, Main.myPlayer);
                    astralCount++;
                }

                if (astralCount == 1)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(50, 0), new Vector2(0, 0), ModContent.ProjectileType<SpawnedAstralBlowpipe>(), 100, 0, Main.myPlayer);
                    astralCount++;
                }

                if (astralCount == 2)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(-50, 0), new Vector2(0, 0), ModContent.ProjectileType<SpawnedAstralBlowpipe>(), 100, 0, Main.myPlayer);
                    astralCount = 0;
                }

                usedM2 = true;
                soundPlayed = false;
                summonTimer = 0;
            }

            if (!usedM2)
            {
                summonTimer++;
            }

            if (summonTimer >= 900)
            {
                if (!soundPlayed)
                {
                    SoundEngine.PlaySound(SoundID.Item29, player.position);
                    soundPlayed = true;
                }
                Dust.NewDust(player.position, player.width, player.height, DustID.HallowedWeapons, 0f, 0f, 0, default(Color), 1.0f);
            }
        }

        public override void UpdateInventory(Player player)
        {
            if (usedM2)
            {
                coolDown--;
                if (coolDown <= 0)
                {
                    SoundEngine.PlaySound(SoundID.Dig, player.position);
                    usedM2 = false;
                    coolDown = 1200;
                }
            }

            BlowpipePlayer.holdingManyBlowpipe = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.HallowedBar, 12)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}