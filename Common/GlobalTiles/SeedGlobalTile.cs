using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Common.GlobalTiles
{
    public class SeedGlobalTile : GlobalTile
    {
        public int Stack;

        public override void KillTile(int i, int j, int type, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            if (BlowpipePlayer.holdingMoreBlowpipe && BlowpipePlayer.holdingManyBlowpipe && BlowpipePlayer.holdingFewBlowpipe)
            {
                if (BlowpipePlayer.holdingManyBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(5, 8));
                }
            }
            else if (BlowpipePlayer.holdingMoreBlowpipe && BlowpipePlayer.holdingManyBlowpipe)
            {
                if (BlowpipePlayer.holdingManyBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(5, 8));
                }
            }
            else if (BlowpipePlayer.holdingFewBlowpipe && BlowpipePlayer.holdingMoreBlowpipe)
            {
                if (BlowpipePlayer.holdingMoreBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(3, 6));
                }
            }
            else if (BlowpipePlayer.holdingFewBlowpipe && BlowpipePlayer.holdingManyBlowpipe)
            {
                if (BlowpipePlayer.holdingManyBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
                {
                    Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(5, 8));
                }
            }
            else if (BlowpipePlayer.holdingMoreBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(3, 6));
            }
            else if (BlowpipePlayer.holdingManyBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(5, 8));
            }
            else if (BlowpipePlayer.holdingFewBlowpipe && type == TileID.Plants && !BlowpipePlayer.blockingSeeds)
            {
                Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 16, 16, ItemID.Seed, Stack = Main.rand.Next(1, 4));
            }

            noItem = false;
        }
    }
}