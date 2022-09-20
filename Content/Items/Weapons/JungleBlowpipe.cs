using blowpipemod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class JungleBlowpipe : ModItem
    {
        public int shotTracker;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Blowpipe");
            Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
                "Every 8th shot summons a jungle orb that locks onto enemies");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 8;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.damage = 20;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(gold: 1, silver: 30);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item63;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            shotTracker++;

            if (shotTracker >= 8)
            {
                Projectile.NewProjectile(source, player.position + new Vector2(0, -75), velocity * 0, ModContent.ProjectileType<JungleOrb>(), damage * 3, knockback, player.whoAmI);
                shotTracker = 0;
            }

            return true;
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingManyBlowpipe = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.JungleSpores, 8)
                .AddIngredient(ItemID.Stinger, 6)
                .AddIngredient(ItemID.Vine, 2)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}