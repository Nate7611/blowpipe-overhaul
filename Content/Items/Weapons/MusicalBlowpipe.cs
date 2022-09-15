using blowpipemod.Common.GlobalTiles;
using blowpipemod.Content.Projectiles;
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
	public class MusicalBlowpipe : ModItem
	{
		SoundStyle MusicalBlowpipeSoundStyle = new SoundStyle("blowpipemod/Assets/Sounds/Items/Blowpipes/MusicalBlowpipeSound_", 4);

		public int randomNote;
		public int musicProjectileTimer;

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Musical Blowpipe");
			Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
                "Converts normal seeds into musical notes \n" +
				"Periodicaly summons musical notes that will heal you on hit\n" +
				"Does not resemble any other weapon...");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults()
		{
			Item.DamageType = DamageClass.Ranged;
			Item.width = 38;
			Item.height = 12;
			Item.useTime = 10;
			Item.useAnimation = 90;
			Item.damage = 50;
			Item.knockBack = 3.5f;
			Item.crit = 0;
			Item.useAmmo = AmmoID.Dart;
			Item.shootSpeed = 15f;
			Item.value = Item.buyPrice(silver: 54);
			Item.rare = ItemRarityID.Orange;
			Item.UseSound = MusicalBlowpipeSoundStyle;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.shoot = ProjectileID.PurificationPowder;
			Item.noMelee = true;
			Item.autoReuse = true;
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (type == ProjectileID.Seed)
            {
				randomNote = Main.rand.Next(1, 4);

				if (randomNote == 1)
                {
					type = ProjectileID.EighthNote;
				}
				if (randomNote == 2)
                {
					type = ProjectileID.QuarterNote;
				}
				if (randomNote == 3)
                {
					type = ProjectileID.TiedEighthNote;
				}
            }
        }

        public override void HoldItem(Player player)
        {
			musicProjectileTimer++;
			if (musicProjectileTimer >= 480)
            {
				if (BlowpipePlayer.musicProjectileSpawned == false)
                {
					Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.position + new Vector2(0, -80), new Vector2(0, 0), ModContent.ProjectileType<MusicalBlowpipeProjectile>(), 100, 0, player.whoAmI);
					musicProjectileTimer = 0;
				}
                else
                {
					musicProjectileTimer = 0;
                }
			}
        }

        public override void UpdateInventory(Player player)
		{
			BlowpipePlayer.holdingManyBlowpipe = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.Blowpipe)
				.AddIngredient(ItemID.CrystalShard, 20)
				.AddIngredient(ItemID.SoulofNight, 8)
				.AddIngredient(ItemID.SoulofSight, 15)
				.AddTile(TileID.Anvils)
				.Register();
		}
	}
}