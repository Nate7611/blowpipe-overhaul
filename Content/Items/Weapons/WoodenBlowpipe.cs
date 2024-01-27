using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class WoodenBlowpipe : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 8;
            Item.useTime = 35;
            Item.useAnimation = 35;
            Item.damage = 6;
            Item.knockBack = 2.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 11f;
            Item.value = Item.buyPrice(silver: 3, copper: 20);
            Item.rare = ItemRarityID.White;
            Item.UseSound = SoundID.Item63;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingFewBlowpipe = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup("Wood", 20)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}