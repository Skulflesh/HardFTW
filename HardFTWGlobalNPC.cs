using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.Events;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.RGB;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using System.Data;

namespace HardFTW
{
	public class HardFTWGlobalNPC : GlobalNPC
	{
		public override void SetDefaults(NPC npc)
		{
			if (Main.getGoodWorld == true)
			{
				// Golem
				if (npc.type == NPCID.GolemHead)
				{
					npc.defense = 30;
				}
				if (npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight)
				{
					npc.defense = 38;
				}
				if (npc.type == NPCID.Golem)
				{
					npc.lifeMax = 14000;
					npc.defense = 35;
				}

				if (npc.type == NPCID.Unicorn) //Unicorn
				{
					npc.knockBackResist = 0.0f;
				}
				if (npc.type == NPCID.GiantTortoise || npc.type == NPCID.IceTortoise) //Tortoises
				{
					npc.knockBackResist = 0.0f;
				}
				if (npc.type == NPCID.Tim) //Tim
				{
					npc.knockBackResist = 0.0f;
					npc.defense = 12;
				}
				if (npc.type == NPCID.RuneWizard) //Rune Wizard
				{
					npc.knockBackResist = 0.0f;
				}
				if (npc.type == NPCID.DarkCaster && Main.hardMode) //Dark Caster
				{
					npc.knockBackResist = 0.0f;
				}
				if (npc.type == NPCID.MeteorHead) //Meteor Head
				{
					npc.knockBackResist = 0.1f;
				}
				if (npc.type == NPCID.ArmoredSkeleton || npc.type == NPCID.HeavySkeleton) //Armored Skeleton
				{
					npc.knockBackResist = 0.1f;
				}
				if (npc.type == NPCID.KingSlime) //King Slime
				{
					npc.lifeMax = 2300;
				}

				//Brain of Cthulhu
				if (npc.type == NPCID.Creeper)
				{
					npc.lifeMax = 90;
					npc.defense = 12;
				}
				if (npc.type == NPCID.BrainofCthulhu)
				{
					npc.lifeMax = 900;
					npc.knockBackResist = 1f;
				}

				//Eater of Worlds
				if (npc.type == NPCID.EaterofWorldsHead)
				{
					npc.lifeMax = 160;
					npc.defense = 6;
				}
				if (npc.type == NPCID.EaterofWorldsBody)
				{
					npc.lifeMax = 180;
					npc.defense = 10;
				}
				if (npc.type == NPCID.EaterofWorldsTail)
				{
					npc.lifeMax = 140;
					npc.defense = 4;
				}

			}
		}
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			base.ModifyNPCLoot(npc, npcLoot);
			if (Main.getGoodWorld) {
				if (npc.type == NPCID.Creeper)
				{
					npcLoot.RemoveWhere(
						rule => rule is DropBasedOnExpertMode drop
							&& drop.ruleForNormalMode is CommonDrop normalDropRule
							&& normalDropRule.itemId == ItemID.TissueSample
					);
					npcLoot.RemoveWhere(
						rule => rule is DropBasedOnExpertMode drop
							&& drop.ruleForExpertMode is CommonDrop expertDropRule
							&& expertDropRule.itemId == ItemID.TissueSample
					);
				}

				//  <8080808080808080808080808080808080808080808(O)=
				// ^^eater of words lol
				if (Main.expertMode == false && Main.masterMode == false)
				{
					if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
					{
						Conditions.LegacyHack_IsBossAndNotExpert bossAndNotExpert = new Conditions.LegacyHack_IsBossAndNotExpert();
						npcLoot.Add(ItemDropRule.ByCondition(bossAndNotExpert, ItemID.ShadowScale, 1, 73, 113, 1));
					}
				}
				if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
				{
					npcLoot.RemoveWhere(
						rule => rule is DropBasedOnExpertMode drop
							&& drop.ruleForNormalMode is CommonDrop normalDropRule
							&& normalDropRule.itemId == ItemID.ShadowScale
					);
					npcLoot.RemoveWhere(
						rule => rule is DropBasedOnExpertMode drop
							&& drop.ruleForExpertMode is CommonDrop expertDropRule
							&& expertDropRule.itemId == ItemID.ShadowScale
					);
				}
                if (npc.type == NPCID.Creeper)
                {
                    npcLoot.RemoveWhere(
                        rule => rule is DropBasedOnExpertMode drop
                            && drop.ruleForNormalMode is CommonDrop normalDropRule
                            && normalDropRule.itemId == ItemID.CrimtaneOre
                    );
                    npcLoot.RemoveWhere(
                        rule => rule is DropBasedOnExpertMode drop
                            && drop.ruleForExpertMode is CommonDrop expertDropRule
                            && expertDropRule.itemId == ItemID.CrimtaneOre
                    );
                    npcLoot.Add(ItemDropRule.Common(ItemID.CrimtaneOre, 2, 2, 5));
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    npcLoot.Add(ItemDropRule.Common(ItemID.TissueSample, 1, 70, 100));
                }
            }
		}
	}
}
	
