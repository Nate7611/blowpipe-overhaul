using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class LeadBlowpipe : ModItem
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
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.damage = 13;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 11f;
            Item.value = Item.buyPrice(silver: 4, copper: 40);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item63;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.IchorDart || type == ProjectileID.CrystalDart || type == ProjectileID.CursedDart || type == ProjectileID.PoisonDartBlowgun)
            {
                damage = (int)(damage * (1.00 - 0.27));
            }
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingFewBlowpipe = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LeadBar, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}