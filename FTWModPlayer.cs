using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

using static Terraria.GameContent.ItemDropRules.Conditions;

namespace HardFTW.FTWModPlayer
{
	public class FTWModPlayer : ModPlayer
	{
        public override void PreUpdateBuffs()
        {
            if (Main.getGoodWorld) { 
                if (Player.ZoneDungeon && !NPC.downedBoss3)
                {
                    Player.AddBuff(BuffID.NoBuilding, 6);
                    Player.noBuilding = true;

                }
                if (Player.ZoneLihzhardTemple && !NPC.downedPlantBoss)
                {
                    Player.AddBuff(BuffID.NoBuilding, 6);
                    Player.noBuilding = true;
                }
                base.PreUpdateBuffs();
            }
        }
    }
}
	
