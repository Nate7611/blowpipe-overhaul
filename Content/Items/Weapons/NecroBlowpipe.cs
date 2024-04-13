using blowpipemod.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class NecroBlowpipe : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 12;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.damage = 31;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(gold: 1, silver: 50);
            Item.rare = ItemRarityID.Orange;
            Item.UseSound = SoundID.Item63;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Seed)
            {
                type = ModContent.ProjectileType<FragileSeedProjectile>();
            }
            else if (type == ProjectileID.IchorDart || type == ProjectileID.CrystalDart || type == ProjectileID.CursedDart || type == ProjectileID.PoisonDartBlowgun)
            {
                damage = (int)(damage * (1.00 - 0.27));
            }
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingMoreBlowpipe = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Blowpipe)
                .AddIngredient(ItemID.Bone, 80)
                .AddIngredient(ItemID.Cobweb, 45)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}