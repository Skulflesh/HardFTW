using Microsoft.Xna.Framework;
using System.Linq;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader;
using Terraria.ID;
using HardFTW.DropConditions;
using HardFTW.Items;
using System.Collections;

namespace HardFTW.Common
{
    public class FTWGlobalItem : GlobalItem
    {
        // Loot from segments/creepers to the bags
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            if (item.type == ItemID.BrainOfCthulhuBossBag)
            {
                itemLoot.Add(ItemDropRule.ByCondition(new FTWDropCondition(), ItemID.TissueSample, 1, 10, 40));
                itemLoot.Add(ItemDropRule.ByCondition(new FTWDropCondition(), ItemID.CrimtaneOre, 1, 85, 100));
                itemLoot.Add(ItemDropRule.ByCondition(new NonFTWMasterDropCondition(), ItemID.TissueSample, 1, 20, 40));
                itemLoot.Add(ItemDropRule.ByCondition(new NonFTWMasterDropCondition(), ItemID.CrimtaneOre, 1, 20, 40));
            }
            if (item.type == ItemID.EaterOfWorldsBossBag)
            {
                itemLoot.Add(ItemDropRule.ByCondition(new FTWDropCondition(), ItemID.ShadowScale, 1, 10, 40));
                itemLoot.Add(ItemDropRule.ByCondition(new FTWDropCondition(), ItemID.DemoniteOre, 1, 100, 120));
                itemLoot.Add(ItemDropRule.ByCondition(new NonFTWMasterDropCondition(), ItemID.ShadowScale, 1, 20, 30));
                itemLoot.Add(ItemDropRule.ByCondition(new NonFTWMasterDropCondition(), ItemID.DemoniteOre, 1, 40, 60));
            }
            if (item.type == ItemID.FloatingIslandFishingCrate)
            {
                itemLoot.RemoveWhere(

                    rule => rule is OneFromOptionsDropRule optionsDropRule
                    && optionsDropRule.dropIds.Length == 4
                );
            }
        }

        //No Sky Sequence Breaking
        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            if (Main.getGoodWorld)
            {
                if (!NPC.downedBoss3)
                {
                    if (item.type == ItemID.BalloonPufferfish || item.type == ItemID.SharkronBalloon || item.type == ItemID.BalloonHorseshoeSharkron /*sharkron balloon*/ || item.type == ItemID.ShinyRedBalloon || item.type == ItemID.HoneyBalloon || item.type == ItemID.BlizzardinaBalloon || item.type == ItemID.CloudinaBalloon || item.type == ItemID.FartInABalloon || item.type == ItemID.SandstorminaBalloon /*red balloon + basic upgrades*/ || item.type == ItemID.BundleofBalloons || item.type == ItemID.WhiteHorseshoeBalloon || item.type == ItemID.YellowHorseshoeBalloon || item.type == ItemID.BlueHorseshoeBalloon || item.type == ItemID.BalloonHorseshoeFart || item.type == ItemID.BalloonHorseshoeHoney /*|| item.type == ItemID.BundleofBalloonsHorseshoe*/)
                    {
                        return false;
                    }
                    if (item.type == ItemID.CreativeWings || item.type == ItemID.TreasureMagnet)
                    {
                        return false;
                    }
                    /*if (item.type == ItemID.LuckyHorseshoe || item.type == ItemID.ObsidianHorseshoe)
                    {
                        return false;
                    }*/
                    if (item.type == ItemID.CobaltShield || item.type == ItemID.ObsidianShield)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss2)
                {
                    if (item.type == ItemID.MeteorHelmet || item.type == ItemID.MeteorSuit || item.type == ItemID.MeteorLeggings)
                    {
                        return false;
                    }
                    if (item.type == ItemID.AncientShadowHelmet || item.type == ItemID.AncientShadowScalemail || item.type == ItemID.AncientShadowGreaves)
                    {
                        return false;
                    }
                    if (item.type == ItemID.FrogLeg || item.type == ItemID.FrogFlipper || item.type == ItemID.FrogWebbing || item.type == ItemID.FrogGear || item.type == ItemID.AmphibianBoots)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss1)
                {
                    if (item.type == ItemID.CrimsonHeart || item.type == ItemID.PanicNecklace || item.type == ItemID.SweetheartNecklace)
                    {
                        return false;
                    }
                    if (item.type == ItemID.ShadowOrb || item.type == ItemID.BandofStarpower || item.type == ItemID.ManaRegenerationBand || item.type == ItemID.MagicCuffs || item.type == ItemID.CelestialCuffs)
                    {
                        return false;
                    }
                }
            }
            return base.CanEquipAccessory(item, player, slot, modded);
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (Main.getGoodWorld)
            {
                if (!NPC.downedBoss3)
                {
                    if (item.type == ItemID.Starfury || item.type == ItemID.WaterBolt || item.type == ItemID.HellwingBow || item.type == ItemID.DarkLance || item.type == ItemID.Flamelash || item.type == ItemID.Sunfury)
                    {
                        return false;
                    }
                    if (item.type == ItemID.Handgun || item.type == ItemID.BlueMoon || item.type == ItemID.Muramasa || item.type == ItemID.Valor || item.type == ItemID.AquaScepter || item.type == ItemID.MagicMissile)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss2)
                {
                    if (item.type == ItemID.AncientShadowHelmet || item.type == ItemID.AncientShadowScalemail || item.type == ItemID.AncientShadowGreaves)
                    {
                        return false;
                    }
                }
                if (!NPC.downedBoss1)
                {
                    if (item.type == ItemID.TheRottedFork || item.type == ItemID.CrimsonRod || item.type == ItemID.TheUndertaker)
                    {
                        return false;
                    }
                    if (item.type == ItemID.BallOHurt || item.type == ItemID.Vilethorn || item.type == ItemID.Musket)
                    {
                        return false;
                    }
                }
            }
            return base.CanUseItem(item, player);
        }

        //Sky Crate tooltip
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            base.ModifyTooltips(item, tooltips);
            if (Main.getGoodWorld)
            {
                if (!NPC.downedBoss3)
                {
                    if (item.type ==ItemID.ShinyRedBalloon|| item.type == ItemID.CreativeWings || item.type == ItemID.CobaltShield || item.type == ItemID.TreasureMagnet)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cursed by the dungeon";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.Starfury || item.type == ItemID.WaterBolt)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cursed by the dungeon";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.Sunfury || item.type == ItemID.HellwingBow || item.type == ItemID.DarkLance || item.type == ItemID.Flamelash)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cursed by the dungeon";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.Handgun || item.type == ItemID.BlueMoon || item.type == ItemID.Muramasa || item.type == ItemID.Valor || item.type == ItemID.AquaScepter || item.type == ItemID.MagicMissile || item.type == ItemID.NightsEdge || item.type == ItemID.SkyFracture)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cursed by the dungeon";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.GoldenKey || item.type == ItemID.ShadowKey)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Loot has been cursed by the dungeon";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.LockBox || item.type == ItemID.ObsidianLockbox)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Lockbox has been cursed by the dungeon";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                }

                if (!NPC.downedQueenBee)
                {
                    if (item.type == ItemID.FrogLeg)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Sorry, post Queen Bee only.";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                }

                if (!NPC.downedBoss2)
                {
                    if (item.type == ItemID.CrimsonFishingCrate || item.type == ItemID.CrimsonFishingCrateHard)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "No Crimson Heart items, yet.";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.CorruptFishingCrate || item.type == ItemID.CorruptFishingCrateHard)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "No Shadow Orb items, yet.";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.AncientShadowHelmet || item.type == ItemID.AncientShadowScalemail || item.type == ItemID.AncientShadowGreaves)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Armor is cursed by the corruption";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.Bomb || item.type == ItemID.Dynamite || item.type == ItemID.BombFish)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Purification Powder may fare better against evil rock for now";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                }
                if (!NPC.downedBoss1)
                {
                    if (item.type == ItemID.TheRottedFork || item.type == ItemID.CrimsonRod || item.type == ItemID.TheUndertaker || item.type == ItemID.CrimsonHeart || item.type == ItemID.PanicNecklace)
                    {
                        //tooltips.emoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cursed by the watcher";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                    if (item.type == ItemID.BallOHurt || item.type == ItemID.Vilethorn || item.type == ItemID.Musket)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cursed by the watcher";
                            line.OverrideColor = Color.Gray;
                        }
                    }
                }
            }
        }
        public override void OnSpawn(Item item, IEntitySource source)
        {
            if (item.type == ItemID.FloatingIslandFishingCrate && Main.getGoodWorld)
            {
                item.ChangeItemType(ModContent.ItemType<LockedSkyCrate>());
            }
            base.OnSpawn(item, source);
        }
        public override void CaughtFishStack(int type, ref int stack)
        {
            if (type == ItemID.FloatingIslandFishingCrate && Main.getGoodWorld)
            {
                stack = 0;
                Main.LocalPlayer.QuickSpawnItem(null, ModContent.ItemType<LockedSkyCrate>(), 1);
            }
            base.CaughtFishStack(type, ref stack);
        }
    }
}

