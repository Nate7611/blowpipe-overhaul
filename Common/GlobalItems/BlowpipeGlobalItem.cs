using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Common.GlobalItems
{
    public class BlowpipeGlobalItem : GlobalItem
    {
        public override bool AppliesToEntity(Item item, bool lateInstatiation)
        {
            return item.type == ItemID.Blowpipe;
        }

        public override void SetDefaults(Item item)
        {
            item.StatsModifiedBy.Add(Mod); // Notify the game that we've made a functional change to this item.
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.Blowpipe)
                .AddIngredient(ItemID.BambooBlock, 12)
                .AddRecipeGroup(RecipeGroupID.IronBar, 2)
                .AddTile(TileID.Anvils)
                .Register();
        }

    }
}
