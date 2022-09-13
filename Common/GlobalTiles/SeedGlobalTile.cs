using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace blowpipemod.Common.GlobalTiles
{
    public class SeedGlobalTile : GlobalTile
    {
        public int Stack;

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (BlowpipePlayer.holdingMoreBlowpipe && BlowpipePlayer.holdingManyBlowpipe)
            {
                if (BlowpipePlayer.holdingManyBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(7, 14));
                }
            }
            else if (BlowpipePlayer.holdingMoreBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(2, 5));
            }
            else if (BlowpipePlayer.holdingManyBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(7, 14));
            }

            noItem = false;  
        }
    }
}   