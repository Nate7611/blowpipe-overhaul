using blowpipemod.Content.Projectiles.BlizzardBlowpipe;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class BlizzardBlowpipe : ModItem
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
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.damage = 200;
            Item.knockBack = 3.5f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(silver: 40);
            Item.rare = ItemRarityID.Blue;
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
                type = ModContent.ProjectileType<BlizzardSeedProjectile>();
            }
        }

        public override void HoldItem(Player player)
        {
            BlowpipePlayer.holdingBlizzardBlowpipe = true;

            if(Main.myPlayer == player.whoAmI)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<Numbers>()] < 1)
                {
                    Projectile.NewProjectile(new EntitySource_Parent(player), player.Center + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<Numbers>(), 0, 0, Main.myPlayer);
                }
            }

            if (BlowpipePlayer.blizzardCounter == 5 && Main.myPlayer == player.whoAmI)
            {
                for (int i = 0; i < 20; i++)
                {
                    Projectile.NewProjectile(new EntitySource_Parent(player), Main.MouseWorld + new Vector2(Main.rand.Next(-150,151), -350 + Main.rand.Next(-10, 151)), new Vector2(0, 0), ModContent.ProjectileType<IceSpike>(), 150, 0, Main.myPlayer);
                }

                BlowpipePlayer.blizzardCounter = 0;
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
                .AddIngredient(ItemID.SnowBlock, 25)
                .AddIngredient(ItemID.IceBlock, 25)
                .AddIngredient(ItemID.IceTorch, 5)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}