using blowpipemod.Content.Projectiles.PlanteraBlowpipeProjectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class PlanteraBlowpipe : ModItem
    {
        public static int planteraShotTracker;
        public static int vineySpinTimer;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 18;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.damage = 100;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(gold: 9);
            Item.rare = ItemRarityID.Lime;
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
                type = ModContent.ProjectileType<VinySeed>();
            }
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            planteraShotTracker++;

            if (planteraShotTracker == 7)
            {
                planteraShotTracker = 1;
            }

            return true;
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingManyBlowpipe = true;

            vineySpinTimer--;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.PlanteraBossBag)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}