using blowpipemod.Content.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Ammo
{
    public class HardenedSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 10;

            Item.damage = 6;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(copper: 2);
            Item.rare = ItemRarityID.White;
            Item.shoot = ModContent.ProjectileType<HardenedSeedProjectile>();

            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            CreateRecipe(75)
                .AddIngredient(ItemID.Seed, 75)
                .AddRecipeGroup(RecipeGroupID.IronBar, 1)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}