using blowpipemod.Common.GlobalTiles;
using blowpipemod.Content.Projectiles;
using blowpipemod.Content.Projectiles.VineyBlowpipe;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using blowpipemod.Content.Items.Ammo;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace blowpipemod.Content.Items.Weapons
{
	public class ZenithBlowpipe : ModItem
	{
		public int shotTracker;
		public int shotLoop = 1;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zenith Blowpipe");
			Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
				"Channels the power of every blowpipe\n" +
				"Right click when the weapon is charged to unleash a laser which will vaperized everything in its path");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 38;
			Item.height = 12;
			Item.useTime = 25;
			Item.useAnimation = 25;
			Item.damage = 100;
			Item.knockBack = 3.5f;
			Item.crit = 0;
			Item.useAmmo = AmmoID.Dart;
			Item.shootSpeed = 15f;
			Item.value = Item.buyPrice(gold: 20);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item63;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.noMelee = true;
			Item.autoReuse = true;
		}

		public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
		{
			if (shotTracker == 1)
			{
				type = ModContent.ProjectileType<VineyBlowpipeHomingProjectile>();
				if (shotLoop == 4)
				{
					shotLoop = 0;
				}
			}
			if (shotTracker == 2)
            {
				type = ModContent.ProjectileType<VineyBlowpipeBallProjectile>();
			}
			if (shotTracker == 3)
			{
				type = ModContent.ProjectileType<VineyBlowpipeVenomProjectile>();
			}
			if (shotTracker == 4)
			{
				type = ModContent.ProjectileType<VineyBlowpipePlanteraProjectile>();
			}
			if (shotTracker == 5)
			{
				if (shotLoop == 1)
                {
					type = ModContent.ProjectileType<VineyBlowpipeSpinProjectile>();
				}
				else
                {
					type = ModContent.ProjectileType<VineyBlowpipeHomingProjectile>();
					damage *= 3;
                }
			}
			if (shotTracker == 6)
			{
				type = ModContent.ProjectileType<VineyBlowpipeHomingProjectile>();
				shotTracker = 0;
				shotLoop++;
			}
		}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
			shotTracker++;
			return true;
        }

        public override void UpdateInventory(Player player)
		{
			BlowpipePlayer.holdingManyBlowpipe = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HellstoneBar, 17)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}