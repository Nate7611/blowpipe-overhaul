using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.Localization;

namespace blowpipemod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class ShroomiteHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault("15% increased seed damage\n" +
				"5% increased ranged critical strike chance");

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 3;
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 28;
			Item.value = Item.sellPrice(gold: 7, silver: 50);
			Item.rare = ItemRarityID.Yellow; 
			Item.defense = 5;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemID.ShroomiteBreastplate && legs.type == ItemID.ShroomiteLeggings;
		}

        public override void UpdateEquip(Player player)
        {
			player.GetDamage(DamageClass.Ranged) += 0.15f;
			player.GetCritChance(DamageClass.Ranged) += 5f;
		}

        public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.Shroomite");
			player.shroomiteStealth = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
				.AddIngredient(ItemID.ShroomiteBar, 12)
				.AddTile(TileID.MythrilAnvil)
				.Register();
		}
	}
}
