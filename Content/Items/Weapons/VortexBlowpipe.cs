using blowpipemod.Common.GlobalTiles;
using blowpipemod.Content.Projectiles.VortexBlowpipe;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using blowpipemod.Content.Items.Ammo;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using Terraria.Audio;

namespace blowpipemod.Content.Items.Weapons
{
	public class VortexBlowpipe : ModItem
	{
		public int pillarCount = 1;
		public int pillarTimer;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex Blowpipe");
			Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
				"Every 8 seconds a mini vortex pillar will spawn above your head\n" +
                "Up to 5 vortex pillars can be attached to you at the same time\n" +
                "Right click to explode the vortex pillars into many very powerful homing seeds\n" +
                "Right clicking will put a 30 second cooldown on pillar generation\n");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 38;
			Item.height = 12;
			Item.useTime = 22;
			Item.useAnimation = 22;
			Item.damage = 100;
			Item.knockBack = 3.5f;
			Item.crit = 0;
			Item.useAmmo = AmmoID.Dart;
			Item.shootSpeed = 15f;
			Item.value = Item.buyPrice(gold: 10);
			Item.rare = ItemRarityID.Red;
			Item.UseSound = SoundID.Item63;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.noMelee = true;
			Item.autoReuse = true;
		}

		public override void HoldItem(Player player)
		{
			pillarTimer++;

			if (pillarTimer == 480)
            {
				Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(-50, 0), new Vector2(0, 0), ModContent.ProjectileType<vort>(), 100, 0, Main.myPlayer);
			}
		}

		public override void UpdateInventory(Player player)
		{
			BlowpipePlayer.holdingManyBlowpipe = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.HallowedBar, 12)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}