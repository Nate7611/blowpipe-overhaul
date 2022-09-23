using blowpipemod.Content.Projectiles.VineyBlowpipe;
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

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Zenith Blowpipe");
            Tooltip.SetDefault("Allows the collection of many seeds for ammo\n" +
                "[i:281]" + "[c/6ECBBD: Channels the power of every blowpipe ]" + "[i:281]" + "\n" +
                "[c/8888A0:Summons 3 buffed astral blowpipes around the player periodically]\n" +
                "[c/22DD97:Summons 2 buffed vortex orbs around the cursor that will automatically explode after a short time]\n" +
                "[c/6BB600:Summons a multi pierce jungle orb above the cursor every 8th shot]\n" +
                "[c/E180CE:Cycles through an enraged Plantera's arsenal]\n" +
                "[c/6374DB:Right click when the weapon is charged to overclock it, massively increasing fire rate at the cost of reduced damage]\n" +
                "[c/6374DB:60% chance not to consume ammo]\n" +
                "Overclocking does [c/FF0000:NOT] affect astral blowpipes\n" +
                "[c/FF0000:(Probably not balanced well, be aware if you are playing with content mods that have post moonlord content!)]");
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Ranged;
            Item.width = 38;
            Item.height = 12;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.damage = 175;
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

            if (jungleShotTracker == 8)
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
            BlowpipePlayer.holdingZenithBlowpipe = true;

            planteraTimer++;

            if (planteraTimer >= 600)
            {
                planteraTracker++;

                //this code sucks... ill fix it later
                if (planteraTracker == 1)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(0, -150), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(50, -150), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-50, -150), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(100, -150), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-100, -150), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(0, -200), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(50, -200), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-50, -200), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(100, -200), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-100, -200), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeBallSpawnedProjectile>(), Item.damage * 2, 0, Main.myPlayer);
                }
                if (planteraTracker == 2)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(100, -400), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipePlanteraSpawnedProjectile>(), Item.damage * 5, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-100, -400), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipePlanteraSpawnedProjectile>(), Item.damage * 5, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(100, 400), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipePlanteraSpawnedProjectile>(), Item.damage * 5, 0, Main.myPlayer);
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-100, 400), new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipePlanteraSpawnedProjectile>(), Item.damage * 5, 0, Main.myPlayer);
                }
                if (planteraTracker == 3)
                {
                    Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld, new Vector2(0, 0), ModContent.ProjectileType<VineyBlowpipeSpinSpawnedProjectile>(), Item.damage, 0, Main.myPlayer);
                }

                if (planteraTracker >= 3)
                {
                    planteraTracker = 0;
                }

                planteraTimer = 0;
            }


            astralTimer++;

            if (astralTimer >= 1200)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(-50, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithAstralBlowpipeRight>(), 100, 0, Main.myPlayer);
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(0, -50), new Vector2(0, 0), ModContent.ProjectileType<ZenithAstralBlowpipeMiddle>(), 100, 0, Main.myPlayer);
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), player.Center + new Vector2(50, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithAstralBlowpipeLeft>(), 100, 0, Main.myPlayer);
                astralTimer = -1200;
            }

            vortexTimer++;

            if (vortexTimer >= 900)
            {
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(70, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithPillarLeft>(), 0, 0, Main.myPlayer);
                Projectile.NewProjectile(player.GetSource_ItemUse_WithPotentialAmmo(player.HeldItem, AmmoID.Dart), Main.MouseWorld + new Vector2(-70, 0), new Vector2(0, 0), ModContent.ProjectileType<ZenithPillarRight>(), 0, 0, Main.myPlayer);
                vortexTimer = -180;
            }

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