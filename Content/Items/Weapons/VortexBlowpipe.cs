using blowpipemod.Content.Projectiles.VortexBlowpipe;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class VortexBlowpipe : ModItem
    {
        public int pillarTimer;
        public int pillarCount = 0;
        public bool isPillarAlive = false;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vortex Blowpipe");
            Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
                "Every 5 seconds a vortex orb will spawn above your head\n" +
                "Up to 3 vortex orbs can be attached to you at the same time\n" +
                "Right click to explode the vortex orbs into many very powerful homing seeds\n" +
                "Right clicking will put a 13 second cooldown on orb generation\n");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 12;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.damage = 85;
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
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(-80, 0), new Vector2(0, 0), ModContent.ProjectileType<VortexPillarRight>(), 0, 0, Main.myPlayer);
                }
                else if (pillarCount == 3)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(80, 0), new Vector2(0, 0), ModContent.ProjectileType<VortexPillarLeft>(), 0, 0, Main.myPlayer);
                }
                else
                {
                    return;
                }

                pillarTimer = 0;
            }

            if (Main.mouseRight && Main.mouseRightRelease && isPillarAlive)
            {
                pillarTimer = -780;
                pillarCount = 0;
                isPillarAlive = false;
            }
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingVortexBlowpipe = true;
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