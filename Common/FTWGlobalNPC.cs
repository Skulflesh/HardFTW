using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using HardFTW.DropConditions;
using HardFTW.Items;
using HardFTW.NPCs.AI;
using HardFTW.NPCs;
using Terraria.WorldBuilding;

namespace HardFTW.Common
{
    public class FTWGlobalNPC : GlobalNPC
    {
        public override void BossHeadSlot(NPC npc, ref int index)
        {
            if (Main.getGoodWorld)
            {

                if (npc.type == NPCID.EaterofWorldsHead)
                {
                    index = -1;
                }
            }

            base.BossHeadSlot(npc, ref index);
        }

        public override void SetDefaults(NPC npc)
        {
            if (Main.getGoodWorld)
            {
                // Golem
                if (npc.type == NPCID.GolemHead)
                {
                    npc.defense = 30;
                    npc.lifeMax = 20000;
                }
                if (npc.type == NPCID.GolemFistLeft || npc.type == NPCID.GolemFistRight)
                {
                    npc.defense = 38;
                    npc.lifeMax = 9000;
                }
                if (npc.type == NPCID.Golem)
                {
                    npc.lifeMax = 12000;
                    npc.defense = 40;
                }

                if (npc.type == NPCID.Unicorn) //Unicorn
                {
                    npc.lifeMax = 360;
                    npc.knockBackResist = 0.0f;
                }
                if (npc.type == NPCID.GiantTortoise || npc.type == NPCID.IceTortoise) //Tortoises
                {
                    npc.knockBackResist = 0f;
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
                if (npc.type == NPCID.MeteorHead) //Meteor Head
                {
                    npc.knockBackResist = 0.1f;
                }
                if (npc.type == NPCID.ArmoredSkeleton) //Armored Skeleton
                {
                    npc.knockBackResist = 0.1f;
                }
                if (npc.type == NPCID.HeavySkeleton) //Armored Skeleton
                {
                    npc.knockBackResist = 0.05f;
                    npc.ScaleStats_UseStrengthMultiplier(1f);
                }
                if (npc.type == NPCID.KingSlime) //King Slime
                {
                    npc.lifeMax = 2300;
                }
                if (npc.type == NPCID.CultistBoss) //Lunatic Cultist
                {
                    npc.lifeMax = 40000;
                    npc.defense = 60;
                    npc.damage = 1;
                    npc.aiStyle = -1;
                }
                if (npc.type == NPCID.CultistBossClone)
                {
                    npc.lifeMax = 38765;
                    npc.aiStyle = -1;
                }
                if (npc.type == NPCID.AncientLight)
                {
                    npc.damage = 100;
                }
                if (npc.type == NPCID.CultistDragonHead)//Phantasm Dragon
                {
                    npc.defense = 10;
                    npc.aiStyle = -1;
                }
                if (npc.type == NPCID.CultistDragonBody1 || npc.type == NPCID.CultistDragonBody2 || npc.type == NPCID.CultistDragonBody3 || npc.type == NPCID.CultistDragonBody4)
                {
                    npc.damage = 1;
                    npc.defense = 50;
                    npc.aiStyle = -1;
                }
                if (npc.type == NPCID.CultistDragonTail)
                {
                    npc.damage = 1;
                    npc.defense = 10;
                    npc.aiStyle = -1;
                }

                //Brain of Cthulhu
                if (npc.type == NPCID.Creeper)
                {
                    npc.lifeMax = 90;
                    npc.defense = 12;
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    npc.lifeMax = 1100;
                    npc.knockBackResist = 0f;
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
            if (npc.type == NPCID.Creeper)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnMasterAndExpertMode drop
                        && drop.ruleForMasterMode is CommonDrop masterDropRule
                        && masterDropRule.itemId == ItemID.CrimtaneOre
                );
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnMasterAndExpertMode drop
                        && drop.ruleForMasterMode is CommonDrop masterDropRule
                        && masterDropRule.itemId == ItemID.TissueSample
                );
                npcLoot.Add(new DropBasedOnMasterAndExpertMode(ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.TissueSample, 3, 2, 5, 2), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.TissueSample, 3, 1, 3, 2), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.TissueSample, 2, 1, 2)));
                npcLoot.Add(new DropBasedOnMasterAndExpertMode(ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.CrimtaneOre, 3, 5, 12, 2), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.CrimtaneOre, 3, 5, 7, 2), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.CrimtaneOre, 3, 2, 4, 2)));
            }

            //  <8080808080808080808080808080808080808080808(O)=
            // ^^eater of words lol
            /*if (!Main.expertMode && !Main.masterMode)
			{
				if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
				{
                    Conditions.LegacyHack_IsBossAndNotExpert bossAndNotExpert = new Conditions.LegacyHack_IsBossAndNotExpert();
                    LeadingConditionRule FTWRule = new LeadingConditionRule(new FTWDropCondition());
                    FTWRule.OnSuccess(ItemDropRule.ByCondition(bossAndNotExpert, ItemID.DemoniteOre, 1, 98, 118, 1));
                    FTWRule.OnSuccess(ItemDropRule.ByCondition(bossAndNotExpert, ItemID.ShadowScale, 1, 103, 143, 1));
                    npcLoot.Add(FTWRule);
                    /*
                    npcLoot.Add(ItemDropRule.ByCondition(bossAndNotExpert, ItemID.DemoniteOre, 1, 98, 118, 1));
                    npcLoot.Add(ItemDropRule.ByCondition(bossAndNotExpert, ItemID.ShadowScale, 1, 103, 143, 1));
                }
			}*/
            if (npc.type == NPCID.EaterofWorldsHead || npc.type == NPCID.EaterofWorldsBody || npc.type == NPCID.EaterofWorldsTail)
            {
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnMasterAndExpertMode drop
                        && drop.ruleForMasterMode is CommonDrop masterDropRule
                        && masterDropRule.itemId == ItemID.DemoniteOre
                );
                npcLoot.RemoveWhere(
                    rule => rule is DropBasedOnMasterAndExpertMode drop
                        && drop.ruleForMasterMode is CommonDrop masterDropRule
                        && masterDropRule.itemId == ItemID.ShadowScale
                );

                npcLoot.Add(new DropBasedOnMasterAndExpertMode(ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.ShadowScale, 2, 1, 2), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.ShadowScale, 2, 1, 2), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.ShadowScale, 10, 1, 2)));
                npcLoot.Add(new DropBasedOnMasterAndExpertMode(ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.DemoniteOre, 2, 2, 5), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.DemoniteOre, 2, 1, 3), ItemDropRule.ByCondition(new NonFTWDropCondition(), ItemID.DemoniteOre, 3, 1, 2)));
            }
            /*if (npc.type == NPCID.BrainofCthulhu)
			{
                LeadingConditionRule NormalmodeRule = new LeadingConditionRule(new NormalDropCondition());
                NormalmodeRule.OnSuccess(ItemDropRule.ByCondition(new FTWDropCondition(), ItemID.TissueSample, 1, 90, 130));
                NormalmodeRule.OnSuccess(ItemDropRule.ByCondition(new NormalDropCondition(), ItemID.CrimtaneOre, 1, 85, 105));
                npcLoot.Add(NormalmodeRule);
                /*npcLoot.Add(ItemDropRule.ByCondition(new NormalDropCondition(), ItemID.TissueSample, 1, 90, 130));
                npcLoot.Add(ItemDropRule.ByCondition(new NormalDropCondition(), ItemID.CrimtaneOre, 1, 85, 105));,
			}*/

        }
        public override Color? GetAlpha(NPC npc, Color lightColor)
        {
            if (npc.type == NPCID.CultistBoss)
            {
                float num = (255 - npc.alpha) / 255f;
                byte b = 210;
                b = (byte)(b * num);
                return new Color(b, b, b, b);
            }
            return base.GetAlpha(npc, lightColor);
        }
        public override bool? DrawHealthBar(NPC npc, byte hbPosition, ref float scale, ref Vector2 position)
        {
            if (Main.getGoodWorld)
            {
                if (npc.type == NPCID.CultistBoss && npc.ai[0] == 6f)
                {
                    return false;
                }
            }
            return base.DrawHealthBar(npc, hbPosition, ref scale, ref position);
        }
        public override bool PreAI(NPC npc)
        {
            if (Main.getGoodWorld)
            {
                if (npc.type == NPCID.CultistBoss)
                {
                    CultistAI.CultistOverrideAI(npc);

                    return false;
                }
                if (npc.type == NPCID.CultistBossClone)
                {
                    CultistAI.CultistOverrideAI(npc);

                    return false;
                }
                if (npc.type == NPCID.CultistDragonHead || npc.type == NPCID.CultistDragonBody1 || npc.type == NPCID.CultistDragonBody2 || npc.type == NPCID.CultistDragonBody3 || npc.type == NPCID.CultistDragonBody4 || npc.type == NPCID.CultistDragonTail)
                {
                    DragonAI.DragonOverrideAI(npc);

                    return false;
                }
                if (npc.type == NPCID.BrainofCthulhu)
                {
                    BrainAI.BrainOverrideAI(npc);

                    return false;
                }
            }
            return base.PreAI(npc);
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            if (Main.getGoodWorld)
            {
                if (npc.type == NPCID.CultistBoss)
                {
                    if (projectile.type == ProjectileID.ShadowJoustingLance || projectile.type == ProjectileID.HallowJoustingLance || projectile.type == ProjectileID.JoustingLance)
                    {
                        modifiers.FinalDamage *= 0.3f;
                    }
                    if (projectile.type == ProjectileID.StarCannonStar || projectile.type == ProjectileID.SuperStar || projectile.type == ProjectileID.SuperStarSlash)
                    {
                        modifiers.FinalDamage *= 0f;
                    }
                }
                if (npc.type >= NPCID.CultistDragonHead && npc.type <= NPCID.CultistDragonTail)
                {
                    if (projectile.type == ProjectileID.StarCannonStar || projectile.type == ProjectileID.SuperStar || projectile.type == ProjectileID.SuperStarSlash)
                    {
                        modifiers.FinalDamage *= 0f;
                    }
                }
            }
            base.ModifyHitByProjectile(npc, projectile, ref modifiers);
        }
        public override bool? CanBeHitByProjectile(NPC npc, Projectile projectile)
        {
            if (Main.getGoodWorld)
            {
                if (npc.type == NPCID.CultistBoss || npc.type == NPCID.CultistBossClone)
                {
                    if (projectile.type == ProjectileID.StarCannonStar || projectile.type == ProjectileID.SuperStar || projectile.type == ProjectileID.SuperStarSlash)
                    {
                        return false;
                    }
                }
                if (npc.type >= NPCID.CultistDragonHead && npc.type <= NPCID.CultistDragonTail)
                {
                    if (projectile.type == ProjectileID.StarCannonStar || projectile.type == ProjectileID.SuperStar || projectile.type == ProjectileID.SuperStarSlash)
                    {
                        return false;
                    }
                }
            }
            return base.CanBeHitByProjectile(npc, projectile);
        }
    }
}

