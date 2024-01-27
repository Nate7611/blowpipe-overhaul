using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Common.GlobalNPCs
{
    class DryadSeed : GlobalNPC
    {
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            if (npc.type == NPCID.Dryad)
            {
                for (int i = 0; i < items.Length; i++)
                {
                    // Check if the slot is null (not filled)
                    if (items[i] == null)
                    {
                        items[i] = new Item();
                        items[i].SetDefaults(ItemID.Seed);
                        items[i].shopCustomPrice = 9;
                        break;
                    }
                }
            }
        }
    }
}