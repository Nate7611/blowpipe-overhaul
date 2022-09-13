using blowpipemod.Common.GlobalTiles;
using blowpipemod.Content.Projectiles.HallowedBlowpipe;
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
	public class HallowedBlowpipe : ModItem
	{
		public int summonTimer;
		public int coolDown = 1200;
		public bool usedM2 = false;
		public bool soundPlayed = false;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Blowpipe");
			Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
				"Right click after this weapon is charged to summon 3 astral blowpipes around your player\n" +
                "Astral blowpipes will shoot homing seeds which explode on impact\n" +
                "The power of the astral blowpipes will need to be recharged after a short time");
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
			Item.value = Item.buyPrice(gold: 4, silver: 60);
			Item.rare = ItemRarityID.Pink;
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
				Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(-50, 0), new Vector2(0, 0), ModContent.ProjectileType<AstralBlowpipeRight>(), 100, 0, Main.myPlayer);
				Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<AstralBlowpipeMiddle>(), 100, 0, Main.myPlayer);
				Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(50, 0), new Vector2(0, 0), ModContent.ProjectileType<AstralBlowpipeLeft>(), 100, 0, Main.myPlayer);
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
					coolDown = 1200;
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