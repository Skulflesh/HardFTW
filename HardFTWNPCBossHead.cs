using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
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
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.WorldBuilding;

namespace HardFTW
{
    public class HardFTWNPCBossHead : GlobalNPC
    {
        public override void BossHeadSlot(NPC npc, ref int index)
        {
            base.BossHeadSlot(npc, ref index);
            if (Main.getGoodWorld)
            {

                if (npc.type == NPCID.BrainofCthulhu)
                {
                    index = -1;
                }
            }
        }
    }
}
	
