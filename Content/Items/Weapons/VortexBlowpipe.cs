using blowpipemod.Content.Projectiles.VortexBlowpipeProjectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class VortexBlowpipe : ModItem
    {
        private int pillarTimer;
        public static int pillarCount = 0;
        private bool isPillarAlive = false;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 12;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.damage = 165;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(gold: 10);
            Item.rare = ItemRarityID.Red;
            Item.UseSound = SoundID.Item63;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void HoldItem(Player player)
        {
            pillarTimer++;

            if (pillarTimer == 300 && Main.myPlayer == player.whoAmI)
            {
                pillarCount++;

                if (pillarCount == 1)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(0, -80), new Vector2(0, 0), ModContent.ProjectileType<VortexPillar>(), 0, 0, Main.myPlayer);
                    isPillarAlive = true;
                }
                else if (pillarCount == 2)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(-80, 0), new Vector2(0, 0), ModContent.ProjectileType<VortexPillar>(), 0, 0, Main.myPlayer);
                }
                else if (pillarCount == 3)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(80, 0), new Vector2(0, 0), ModContent.ProjectileType<VortexPillar>(), 0, 0, Main.myPlayer);
                }
                else
                {
                    return;
                }

                pillarTimer = 0;
            }

            if (Main.mouseRight && Main.mouseRightRelease && isPillarAlive)
            {
                pillarTimer = -300;
                pillarCount = 0;
                isPillarAlive = false;
            }
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingManyBlowpipe = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FragmentVortex, 18)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}