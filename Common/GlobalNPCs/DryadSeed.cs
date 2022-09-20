using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Common.GlobalNPCs
{
    class DryadSeed : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            if (type == NPCID.Dryad)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Seed);
                shop.item[nextSlot].shopCustomPrice = 9;
                nextSlot++;
            }
        }
    }
}