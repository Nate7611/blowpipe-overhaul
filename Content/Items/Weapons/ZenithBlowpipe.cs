using blowpipemod.Common.GlobalTiles;
using blowpipemod.Content.Projectiles.ZenithBlowpipe;
using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;
using blowpipemod.Content.Items.Ammo;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using System;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Graphics.Shaders;
using ReLogic.Content;
using Terraria.Audio;

namespace blowpipemod.Content.Items.Weapons
{
	public class ZenithBlowpipe : ModItem
	{
		public int shotTracker = 1;
		public int overclockCooldown;
		public int overclockTimer;
		public int coolDown = 300;
		public bool usedM2 = false;
		public bool soundPlayed = false;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Zenith Blowpipe");
			Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
				"[i:281]" + "[c/6ECBBD: Channels the power of every blowpipe ]" + "[i:281]" + "\n" +
				"Summons 3 buffed astral blowpipes around the player periodically\n" +
                "Summons 4 buffed vortex orbs around the cursor that will automatically explode after a short time\n" +
				"Right click when the weapon is charged to overclock it, massively increasing fire rate at the cost of reduced damage\n" +
                "Overclocking does NOT affect astral blowpipes");
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

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float numberProjectiles = 3;
			float rotation = MathHelper.ToRadians((float)(Math.PI / 2));
			position += Vector2.Normalize(velocity) * 45f;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
				Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<ZenithBlowpipeProjectile>(), damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void HoldItem(Player player)
		{
			if (Main.mouseRight && overclockCooldown >= 780)
			{
				SoundEngine.PlaySound(SoundID.Item25, player.position);
				usedM2 = true;
				soundPlayed = false;
				overclockCooldown = 0;
				overclockTimer = 300;
			}

			overclockTimer--;

			if (overclockTimer >= 0)
            {
				Item.useTime = 5;
				Item.useAnimation = 5;
				Item.damage = (int)(100 * 0.25);
			}
			else
            {
				Item.useTime = 25;
				Item.useAnimation = 25;
				Item.damage = 100;
			}

			if (!usedM2)
			{
				overclockCooldown++;
			}

			if (overclockCooldown >= 780)
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
				.AddIngredient(ItemID.HellstoneBar, 17)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}