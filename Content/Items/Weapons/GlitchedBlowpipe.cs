using blowpipemod.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class GlitchedBlowpipe : ModItem
    {
        public int randomTextAssigner;
        public int randomUse;
        public string finalText;
        public string randomText = null;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 39;
            Item.height = 23;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.damage = 0;
            Item.knockBack = 0;
            Item.crit = 0;
            Item.useAmmo = AmmoID.Dart;
            Item.shootSpeed = 15f;
            Item.value = Item.buyPrice(gold: 1, silver: 70);
            Item.rare = ItemRarityID.Pink;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ProjectileID.PurificationPowder;
            Item.noMelee = true;
            Item.autoReuse = true;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (randomText == null)
            {
                finalText = "An Unknown Error Has Occurred";
            }
            else
            {
                finalText = randomText;
            }

            var line = new TooltipLine(Mod, "RandomText", finalText);
            tooltips.Add(line);
            line.Text = finalText;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            randomUse = Main.rand.Next(18, 32);

            Item.useTime = randomUse;
            Item.useAnimation = randomUse;

            Item.crit = Main.rand.Next(0, 5);

            Item.shootSpeed = Main.rand.Next(1, 16);

            float numberProjectiles = Main.rand.Next(1, 12);
            float rotation = MathHelper.ToRadians((float)(Math.PI / 2));
            position += Vector2.Normalize(velocity) * 45f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = velocity.RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 1f;
                Projectile.NewProjectile(source, position, perturbedSpeed, ModContent.ProjectileType<GlitchedProjectile>(), Main.rand.Next(1, 89), Main.rand.Next(1, 16), player.whoAmI);
            }
            return false;
        }

        public override void UpdateInventory(Player player)
        {
            BlowpipePlayer.holdingManyBlowpipe = true;
            if (!BlowpipePlayer.holdingGlitchedBlowpipe)
            {
                randomText = null;
            }

        }

        public override void HoldItem(Player player)
        {
            BlowpipePlayer.holdingGlitchedBlowpipe = true;

            randomTextAssigner = Main.rand.Next(1, 11);

            if (randomTextAssigner == 1)
            {
                randomText = "[c/FF2525:na3lMI2l*%9X#Q50nbJB4HcKfRZ6zz*gyTQQM$qPzE2w]";
            }
            if (randomTextAssigner == 2)
            {
                randomText = "[c/FF2525:JyXWyXU1QDc6&x$16DXzRtny*iJhNsKBVc1WPGSqmxfG]";
            }
            if (randomTextAssigner == 3)
            {
                randomText = "[c/FF2525:FJ6SugEkDrjlW#81mm7BGWd5WbJDC&cE$ZiA9KcAY5Yq]";
            }
            if (randomTextAssigner == 4)
            {
                randomText = "[c/FF2525:S2ktlQ83s^1sVya*M%^7RORcU0Q0p$WvV!LXbanTeNWf]";
            }
            if (randomTextAssigner == 5)
            {
                randomText = "[c/FF2525:^V169gbn!BYsj6hR*S7eMqh3#BG%d71ozHtw$@M9llvz]";
            }
            if (randomTextAssigner == 6)
            {
                randomText = "[c/FF2525:5@vxPZ6H3dQs9cs53a8@tlL0VaLOC*m#eWsx@@d7qQuE]";
            }
            if (randomTextAssigner == 7)
            {
                randomText = "[c/FF2525:nxV93k7Psx&#L8Q0wEr*ipFzRY%%cYLaAp#2M2ldv6pA]";
            }
            if (randomTextAssigner == 8)
            {
                randomText = "[c/FF2525:v97Zx5GkAaDlzVd%4M8oAv5jBq0Eoa$%R4KINj4yCIPA]";
            }
            if (randomTextAssigner == 9)
            {
                randomText = "[c/FF2525:W$Qto9jUV^x21rWT*oVTJ&8udsvisaAgUo$^UjgnEN1B]";
            }
            if (randomTextAssigner == 10)
            {
                randomText = "[c/FF2525:%sEJkYBSY2hpMfyf@1GdFBQ3ar!a4L^#3rdWc&iN4YT0]";
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Blowpipe, 1)
                .AddIngredient(ItemID.HallowedBar, 15)
                .AddIngredient(ItemID.SoulofFright, 10)
                .AddIngredient(ItemID.SoulofMight, 10)
                .AddIngredient(ItemID.SoulofSight, 10)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}