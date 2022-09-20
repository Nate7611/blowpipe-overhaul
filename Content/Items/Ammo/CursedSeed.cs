using blowpipemod.Content.Projectiles;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Ammo
{
    public class CursedSeed : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cursed Seed");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 10;

            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;

            Item.maxStack = 999;
            Item.consumable = true;
            Item.knockBack = 2f;
            Item.value = Item.sellPrice(copper: 6);
            Item.rare = ItemRarityID.Orange;
            Item.shoot = ModContent.ProjectileType<CursedSeedProjectile>();

            Item.ammo = AmmoID.Dart;
        }

        public override void AddRecipes()
        {
            CreateRecipe(150)
                .AddIngredient(ItemID.Seed, 150)
                .AddIngredient(ItemID.CursedFlame, 1)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}