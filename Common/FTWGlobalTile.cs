using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.IO;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.WorldBuilding;


using static Terraria.GameContent.ItemDropRules.Conditions;

namespace HardFTW.Common
{
    public class FTWGlobalTile : GlobalTile
    {
        // Loot from segments/creepers to the bags
        public override bool CanExplode(int i, int j, int type)
        {
            if (Main.getGoodWorld)
            {
                if (!NPC.downedBoss1)
                {
                    if (type == TileID.Demonite || type == TileID.Crimtane)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss2)
                {
                    if (type == TileID.Ebonstone || type == TileID.Crimstone || type == WallID.CrimstoneUnsafe || type == WallID.EbonstoneUnsafe || type == TileID.ShadowOrbs)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss3)
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
            if (Main.getGoodWorld)
            {
                if (!NPC.downedBoss3)
                {
                    if (type == TileID.BlueDungeonBrick || type == TileID.GreenDungeonBrick || type == TileID.PinkDungeonBrick || type == WallID.PinkDungeonUnsafe || type == WallID.PinkDungeonSlabUnsafe || type == WallID.PinkDungeonTileUnsafe || type == WallID.GreenDungeonUnsafe || type == WallID.GreenDungeonSlabUnsafe || type == WallID.GreenDungeonTileUnsafe || type == WallID.BlueDungeonUnsafe || type == WallID.BlueDungeonSlabUnsafe || type == WallID.BlueDungeonTileUnsafe)
                    {
                        return false;
                    }
                    if (type == TileID.BewitchingTable || type == TileID.AlchemyTable || type == TileID.WaterCandle || type == TileID.Books)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss2)
                {
                    if (type == TileID.Ebonstone || type == TileID.Crimstone || type == WallID.CrimstoneUnsafe || type == WallID.EbonstoneUnsafe || type == TileID.ShadowOrbs)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss1)
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
                if (!NPC.downedGolemBoss)
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

