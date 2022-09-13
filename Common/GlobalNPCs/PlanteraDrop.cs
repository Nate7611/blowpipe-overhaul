using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using blowpipemod.Content.Items.Weapons;

namespace blowpipemod
{
	public class PlanteraDrop : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (npc.type == NPCID.Plantera)
			{
				npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<VineyBlowpipe>()));
			}
		}
	}
}