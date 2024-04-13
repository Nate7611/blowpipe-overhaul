using blowpipemod.Content.Projectiles.MusicalBlowpipe;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class MusicalBlowpipe : ModItem
    {
        SoundStyle MusicalBlowpipeSoundStyle = new SoundStyle("blowpipemod/Assets/Sounds/Items/Blowpipes/MusicalBlowpipeSound_", 4);

        public int randomNote;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 10;
            Item.useTime = 10;
            Item.useAnimation = 90;
            Item.damage = 36;
            Item.knockBack = 2f;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(gold: 2, silver: 54);
            Item.rare = ItemRarityID.Pink;
            Item.UseSound = MusicalBlowpipeSoundStyle;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            randomNote = Main.rand.Next(1, 4);

            if (type == ProjectileID.Seed)
            {
                if (randomNote == 1)
                {
                    type = ModContent.ProjectileType<QuarterNote>();
                }
                if (randomNote == 2)
                {
                    type = ModContent.ProjectileType<TiedEighthNote>();
                }
                if (randomNote == 3)
                {
                    type = ModContent.ProjectileType<EighthNote>();
                }
            }
            else if (type == ProjectileID.IchorDart || type == ProjectileID.CrystalDart || type == ProjectileID.CursedDart || type == ProjectileID.PoisonDart)
            {
                damage = (int)(damage * (1.00 - .55));
            }
        }

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .25f;
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
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}