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
using Terraria.GameContent.ObjectInteractions;
using Terraria.GameContent.UI;
using Terraria.GameContent.Biomes.CaveHouse;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using Terraria.ModLoader.IO;
using Terraria.ID;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.ObjectData;
using Terraria.WorldBuilding;

using static Terraria.GameContent.ItemDropRules.Conditions;

namespace HardFTW.Common
{
    public class FTWGlobalWall : GlobalWall
    {
        // Loot from segments/creepers to the bags
        public override bool CanExplode(int i, int j, int type)
        {
            if (Main.getGoodWorld)
            {
                if (!NPC.downedBoss2)
                {
                    if (type == WallID.CrimstoneUnsafe || type == WallID.EbonstoneUnsafe)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss3)
                {
                    if (type == WallID.PinkDungeonUnsafe || type == WallID.PinkDungeonSlabUnsafe || type == WallID.PinkDungeonTileUnsafe || type == WallID.GreenDungeonUnsafe || type == WallID.GreenDungeonSlabUnsafe || type == WallID.GreenDungeonTileUnsafe || type == WallID.BlueDungeonUnsafe || type == WallID.BlueDungeonSlabUnsafe || type == WallID.BlueDungeonTileUnsafe)
                    {
                        return false;
                    }
                }
            }
            return base.CanExplode(i, j, type);
        }
        public override void KillWall(int i, int j, int type, ref bool fail)
        {
            if (Main.getGoodWorld)
            {
                if (!NPC.downedBoss3)
                {
                    if (type == WallID.PinkDungeonUnsafe || type == WallID.PinkDungeonSlabUnsafe || type == WallID.PinkDungeonTileUnsafe || type == WallID.GreenDungeonUnsafe || type == WallID.GreenDungeonSlabUnsafe || type == WallID.GreenDungeonTileUnsafe || type == WallID.BlueDungeonUnsafe || type == WallID.BlueDungeonSlabUnsafe || type == WallID.BlueDungeonTileUnsafe)
                    {
                        fail = true;
                    }
                }
                if (!NPC.downedBoss2)
                {
                    if (type == WallID.CrimstoneUnsafe || type == WallID.EbonstoneUnsafe)
                    {
                        fail = true;
                    }
                }

            }
            base.KillWall(i, j, type, ref fail);
        }
    }
}

