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

namespace HardFTW
{
	public class HardFTWBuffLoader: GlobalBuff
	{
        public override void Update(int type, Player player, ref int buffIndex)
        {
            if (Main.getGoodWorld == true && NPC.downedBoss3 == false)
            {
                player.buffImmune[BuffID.Bewitched] = true;
            }
            base.Update(type, player, ref buffIndex);
        }
    }
}
	
