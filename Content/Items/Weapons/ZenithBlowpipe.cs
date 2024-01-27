using blowpipemod.Content.Projectiles.PlanteraBlowpipeProjectiles;
using blowpipemod.Content.Projectiles.ZenithBlowpipe;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.GameContent.Creative;
using Terraria.ID;
using Terraria.ModLoader;

namespace blowpipemod.Content.Items.Weapons
{
    public class ZenithBlowpipe : ModItem
    {
        public int jungleShotTracker;
        public int planteraTracker;
        public int overclockCooldown;
        public int overclockTimer;
        public int vortexTimer;
        public int astralTimer;
        public int planteraTimer;
        public int coolDown = 300;
        public bool usedM2 = false;
        public bool soundPlayed = false;
        private Vector2[] ballPositions;

        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 66;
            Item.height = 16;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.damage = 400;
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
            jungleShotTracker++;

            if (jungleShotTracker == 12 && Main.myPlayer == player.whoAmI)
            {
                Projectile.NewProjectile(source, Main.MouseWorld + new Vector2(0, -75), velocity * 0, ModContent.ProjectileType<ZenithJungleOrb>(), damage * 5, knockback * 0, player.whoAmI);
                jungleShotTracker = 0;
            }

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

        public override bool CanConsumeAmmo(Item ammo, Player player)
        {
            return Main.rand.NextFloat() >= .60f;
        }

        public override void HoldItem(Player player)
        {
            planteraTimer++;

            if (planteraTimer >= 600 && Main.myPlayer == player.whoAmI)
            {
                planteraTracker++;

                if (planteraTracker == 1)
                {
                    ballPositions = new Vector2[]
                    {
                        new Vector2(0, -150),
                        new Vector2(50, -150),
                        new Vector2(-50, -150),
                        new Vector2(100, -150),
                        new Vector2(-100, -150),
                    };

                    for (int d = 0; d < ballPositions.Length; d++)
                    {
                        Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + ballPositions[d], new Vector2(0, 0), ModContent.ProjectileType<VinyBall>(), Item.damage * 3, 0, Main.myPlayer);
                        Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + ballPositions[d] + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<VinyBall>(), Item.damage * 3, 0, Main.myPlayer);
                    }
                }
                if (planteraTracker == 2)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(100, -400), new Vector2(0, 0), ModContent.ProjectileType<VinyPlantera>(), Item.damage * 5, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-100, -400), new Vector2(0, 0), ModContent.ProjectileType<VinyPlantera>(), Item.damage * 5, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(100, 400), new Vector2(0, 0), ModContent.ProjectileType<VinyPlantera>(), Item.damage * 5, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-100, 400), new Vector2(0, 0), ModContent.ProjectileType<VinyPlantera>(), Item.damage * 5, 0, Main.myPlayer);
                }
                if (planteraTracker == 3)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld, new Vector2(0, 0), ModContent.ProjectileType<VinySpinner>(), Item.damage, 0, Main.myPlayer);
                }

                if (planteraTracker >= 3)
                {
                    planteraTracker = 0;
                }

                planteraTimer = 0;
            }

            astralTimer++;

            if (astralTimer >= 1200 && Main.myPlayer == player.whoAmI)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(-50, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithAstralBlowpipeRight>(), 100, 0, Main.myPlayer);
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<ZenithAstralBlowpipeMiddle>(), 100, 0, Main.myPlayer);
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(50, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithAstralBlowpipeLeft>(), 100, 0, Main.myPlayer);
                astralTimer = -1200;
            }

            vortexTimer++;

            if (vortexTimer >= 900 && Main.myPlayer == player.whoAmI)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(70, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithPillarLeft>(), 0, 0, Main.myPlayer);
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-70, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithPillarRight>(), 0, 0, Main.myPlayer);
                vortexTimer = -180;
            }

            if (Main.mouseRight && overclockCooldown >= 780 && Main.myPlayer == player.whoAmI)
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
                Dust.NewDust(player.position, player.width, player.height, DustID.UndergroundHallowedEnemies, 0f, 0f, 0, default(Color), 1.0f);
            }
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
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VortexBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<PlanteraBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<HallowedBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<CrystalBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<MusicalBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<AdamantiteBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<HellstoneBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<NecroBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<JungleBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<IceBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<WoodenBlowpipe>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<VortexBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<PlanteraBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<HallowedBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<CrystalBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<MusicalBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<TitaniumBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<HellstoneBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<NecroBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<JungleBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<IceBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<WoodenBlowpipe>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}