using blowpipemod.Content.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Ammo
{
    public class SlimeySeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Slimy Seed");
            Tooltip.SetDefault("Has a certain bouncy quality to it\n" +
                "Can pierce 1 enemy if it's the first thing it hits");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 10;

            Item.damage = 5;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(copper: 2);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<SlimeySeedProjectile>();

            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            CreateRecipe(75)
                .AddIngredient(ItemID.Seed, 75)
                .AddIngredient(ItemID.Gel, 6)
                .AddTile(TileID.Solidifier)
                .Register();
        }
    }
}