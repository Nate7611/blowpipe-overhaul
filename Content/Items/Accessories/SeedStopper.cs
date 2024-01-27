using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Accessories
{
    public class SeedStopper : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.rare = ItemRarityID.White;
            Item.value = Item.sellPrice(gold: 7, silver: 50);
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.blockingSeeds = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Seed, 99)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}