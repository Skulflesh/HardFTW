using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.IO;
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
using Terraria.WorldBuilding;

namespace HardFTW
{
	public class HardFTWGlobalTile : GlobalTile
	{
        // Loot from segments/creepers to the bags
        public override bool CanExplode(int i, int j, int type)
        {
            if (Main.getGoodWorld == true)
            {
                if (NPC.downedBoss1 == false)
                {
                    if (type == TileID.Demonite || type == TileID.Crimtane)
                    {
                        return false;
                    }
                }
                if (NPC.downedBoss2 == false)
                {
                    if (type == TileID.Ebonstone || type == TileID.Crimstone || type == WallID.CrimstoneUnsafe || type == WallID.EbonstoneUnsafe || type == TileID.ShadowOrbs)
                    {
                        return false;
                    }
                }
                if (NPC.downedBoss3 == false)
                {
                    if (type == TileID.BewitchingTable || type == TileID.AlchemyTable || type == TileID.WaterCandle || type == TileID.Books)
                    {
                        return false;
                    }
                }
            }
            return base.CanExplode(i, j, type);
        }
        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            if (Main.getGoodWorld == true)
            {
                if (NPC.downedBoss3 == false)
                {
                    if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick)
                    {
                        return false;
                    }
                    if (type == TileID.BewitchingTable || type == TileID.AlchemyTable || type == TileID.WaterCandle || type == TileID.Books)
                    {
                        return false;
                    }
                }
                if (NPC.downedBoss2 == false)
                {
                    if (type == WallID.CrimstoneUnsafe || type == WallID.EbonstoneUnsafe || type == TileID.ShadowOrbs)
                    {
                        return false;
                    }
                }
                if (NPC.downedBoss1 == false)
                {
                    if (type == TileID.Demonite || type == TileID.Crimtane)
                    {
                        return false;
                    }
                }
            }
            return base.CanKillTile(i, j, type, ref blockDamaged);
        }

        public override bool Slope(int i, int j, int type)
        {
            if (Main.getGoodWorld)
            {
                if (NPC.downedGolemBoss == false)
                {
                    if (type == TileID.LihzahrdBrick)
                    {
                        return false;
                    }
                    
                }
            }
            return base.Slope(i, j, type);
        }
    }
}
	
