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
		public int summonTimer;
		public int coolDown = 300;
		public bool usedM2 = false;
		public bool soundPlayed = false;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex Blowpipe");
			Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
				"\n");
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

		public override bool AltFunctionUse(Player player)
		{
			return true;
		}

		public override bool CanShoot(Player player)
		{
			if (player.altFunctionUse == 2 && summonTimer >= 600)
			{
				SoundEngine.PlaySound(SoundID.Item25, player.position);
				Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center, new Vector2(0, 0), ModContent.ProjectileType<VortexLaser>(), 100, 0, Main.myPlayer);
				usedM2 = true;
				soundPlayed = false;
				summonTimer = 0;
			}
			return true;
		}

		public override void HoldItem(Player player)
		{
			if (!usedM2)
			{
				summonTimer++;
			}

			if (summonTimer >= 600)
			{
				if (!soundPlayed)
				{
					SoundEngine.PlaySound(SoundID.Item29, player.position);
					soundPlayed = true;
				}
				Dust.NewDust(player.position, player.width, player.height, DustID.HallowedWeapons, 0f, 0f, 0, default(Color), 1.0f);
			}

			BlowpipePlayer.holdingHallowedBlowpipe = true;
		}

		public override void UpdateInventory(Player player)
		{
			if (usedM2)
			{
				coolDown--;
				if (coolDown <= 0)
				{
					SoundEngine.PlaySound(SoundID.Dig, player.position);
					usedM2 = false;
					coolDown = 300;
				}
			}

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