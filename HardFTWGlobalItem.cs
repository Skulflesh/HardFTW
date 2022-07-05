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
	public class HardFTWGlobalItem : GlobalItem
	{
        // Loot from segments/creepers to the bags
        public override void OpenVanillaBag(string context, Player player, int arg)
        {
            base.OpenVanillaBag(context, player, arg);
            if (Main.getGoodWorld == true)
            {
                if (arg == ItemID.BrainOfCthulhuBossBag)
                {
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.BrainOfCthulhuBossBag), ItemID.TissueSample, Main.rand.Next(160, 220));
                }
                if (arg == ItemID.EaterOfWorldsBossBag)
                {
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.EaterOfWorldsBossBag), ItemID.ShadowScale, Main.rand.Next(160, 220));
                    player.QuickSpawnItem(player.GetSource_OpenItem(ItemID.EaterOfWorldsBossBag), ItemID.DemoniteOre, Main.rand.Next(100, 100));
                }
         
            }
        }

        //No Sky Sequence Breaking
        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            if (Main.getGoodWorld == true)
            {
                if (NPC.downedBoss3 == false)
                {
                    if (item.type == ItemID.BalloonPufferfish || item.type == ItemID.SharkronBalloon || item.type == ItemID.BalloonHorseshoeSharkron || item.type == ItemID.ShinyRedBalloon || item.type == ItemID.HoneyBalloon || item.type == ItemID.BlizzardinaBalloon || item.type == ItemID.CloudinaBalloon || item.type == ItemID.FartInABalloon || item.type == ItemID.SandstorminaBalloon || item.type == ItemID.BundleofBalloons || item.type == ItemID.WhiteHorseshoeBalloon || item.type == ItemID.YellowHorseshoeBalloon || item.type == ItemID.BlueHorseshoeBalloon || item.type == ItemID.BalloonHorseshoeFart || item.type == ItemID.BalloonHorseshoeHoney)
                    {
                        return false;
                    }
                    if (item.type == ItemID.CreativeWings || item.type == ItemID.TreasureMagnet)
                    {
                        return false;
                    }
                    if (item.type == ItemID.CobaltShield || item.type == ItemID.ObsidianShield)
                    {
                        return false;
                    }
                }
                if (NPC.downedBoss2 == false)
                {
                    if (item.type == ItemID.MeteorHelmet || item.type == ItemID.MeteorSuit || item.type == ItemID.MeteorLeggings)
                    {
                        return false;
                    }
                    if (item.type == ItemID.FrogLeg || item.type == ItemID.FrogFlipper || item.type == ItemID.FrogWebbing || item.type == ItemID.FrogGear || item.type == ItemID.AmphibianBoots)
                    {
                        return false;
                    }
                }
            }
            return base.CanEquipAccessory(item, player, slot, modded);
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (Main.getGoodWorld == true)
            {
                if (NPC.downedBoss3 == false)
                {
                    if (item.type == ItemID.FloatingIslandFishingCrate || item.type == ItemID.Starfury || item.type == ItemID.GoldenKey || item.type == ItemID.WaterBolt || item.type == ItemID.HellwingBow || item.type == ItemID.DarkLance || item.type == ItemID.Flamelash || item.type == ItemID.Sunfury)
                    {
                        return false;
                    }
                    if (item.type == ItemID.Handgun || item.type == ItemID.PhoenixBlaster || item.type == ItemID.BlueMoon || item.type == ItemID.Muramasa || item.type == ItemID.Valor || item.type == ItemID.AquaScepter || item.type == ItemID.MagicMissile ||item.type == ItemID.NightsEdge)
                    {
                        return false;
                    }
                }
                if (NPC.downedBoss2 == false)
                {
                    if (item.type == ItemID.StarCannon || item.type == ItemID.SpaceGun || item.type == ItemID.MeteorHamaxe)
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
            if (Main.getGoodWorld == true)
            {
                if (NPC.downedBoss3 == false)
                {
                    /*if (item.type == ItemID.BalloonPufferfish || item.type == ItemID.SharkronBalloon || item.type == ItemID.BalloonHorseshoeSharkron || item.type == ItemID.ShinyRedBalloon || item.type == ItemID.HoneyBalloon || item.type == ItemID.BlizzardinaBalloon || item.type == ItemID.CloudinaBalloon || item.type == ItemID.FartInABalloon || item.type == ItemID.SandstorminaBalloon || item.type == ItemID.BundleofBalloons || item.type == ItemID.WhiteHorseshoeBalloon || item.type == ItemID.YellowHorseshoeBalloon || item.type == ItemID.BlueHorseshoeBalloon || item.type == ItemID.BalloonHorseshoeFart || item.type == ItemID.BalloonHorseshoeHoney || item.type == ItemID.CreativeWings || item.type == ItemID.CobaltShield || item.type == ItemID.ObsidianShield || item.type == ItemID.TreasureMagnet)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cannot be equipped pre-Skeletron";
                        }
                    }
                    if (item.type == ItemID.Starfury || item.type == ItemID.WaterBolt || item.type == ItemID.HellwingBow || item.type == ItemID.DarkLance || item.type == ItemID.Flamelash)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cannot be used pre-Skeletron";
                        }
                    }
                    if (item.type == ItemID.Sunfury || item.type == ItemID.Handgun || item.type == ItemID.PhoenixBlaster || item.type == ItemID.BlueMoon || item.type == ItemID.Muramasa || item.type == ItemID.Valor || item.type == ItemID.AquaScepter || item.type == ItemID.MagicMissile || item.type == ItemID.NightsEdge)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cannot be used pre-Skeletron";
                        }
                    }*/
                    if (item.type == ItemID.FloatingIslandFishingCrate || item.type == ItemID.LockBox)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Loot inside cannot be used pre-Skeletron";
                        }
                    }
                    if (item.type == ItemID.GoldenKey || item.type == ItemID.DungeonFishingCrate)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Golden Chest loot inside cannot be used pre-Skeletron";
                        }
                    }
                    if (item.type == ItemID.ShadowKey || item.type == ItemID.ObsidianLockbox)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Shadow chest loot cannot be used pre-Skeletron";
                        }
                    }
                }
                if (NPC.downedBoss2 == false)
                {
                    /*if (item.type == ItemID.FrogLeg || item.type == ItemID.FrogFlipper || item.type == ItemID.FrogWebbing || item.type == ItemID.FrogGear || item.type == ItemID.AmphibianBoots || item.type == ItemID.MeteorHelmet || item.type == ItemID.MeteorSuit || item.type == ItemID.MeteorLeggings)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cannot be equipped before BoC/EoW";
                        }
                    }
                    if (item.type == ItemID.StarCannon || item.type == ItemID.SpaceGun || item.type == ItemID.MeteorHamaxe)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Cannot be used before BoC/EoW";
                        }
                    }*/
                    if (item.type == ItemID.MeteoriteBar)
                    {
                        //tooltips.RemoveAll(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        TooltipLine line = tooltips.FirstOrDefault(x => x.Name == "Tooltip0" && x.Mod == "Terraria");
                        if (line != null)
                        {
                            line.Text = "Items crafted cannot be used pre-Skeletron";
                        }
                    }
                }
            }
        
        }

        public override void SetDefaults(Item item)
        {
            if (Main.getGoodWorld == true)
            {
                if (NPC.downedBoss3 == false)
                {
                    base.SetDefaults(item);
                    if (item.type == ItemID.BalloonPufferfish || item.type == ItemID.SharkronBalloon || item.type == ItemID.BalloonHorseshoeSharkron || item.type == ItemID.ShinyRedBalloon || item.type == ItemID.HoneyBalloon || item.type == ItemID.BlizzardinaBalloon || item.type == ItemID.CloudinaBalloon || item.type == ItemID.FartInABalloon || item.type == ItemID.SandstorminaBalloon || item.type == ItemID.BundleofBalloons || item.type == ItemID.WhiteHorseshoeBalloon || item.type == ItemID.YellowHorseshoeBalloon || item.type == ItemID.BlueHorseshoeBalloon || item.type == ItemID.BalloonHorseshoeFart || item.type == ItemID.BalloonHorseshoeHoney || item.type == ItemID.CreativeWings || item.type == ItemID.CobaltShield || item.type == ItemID.ObsidianShield || item.type == ItemID.TreasureMagnet)
                    {
                        item.rare = -1;
                    }
                    if (item.type == ItemID.Starfury || item.type == ItemID.GoldenKey || item.type == ItemID.WaterBolt || item.type == ItemID.HellwingBow || item.type == ItemID.DarkLance || item.type == ItemID.Flamelash)
                    {
                        item.rare = -1;
                    }
                    if (item.type == ItemID.Sunfury || item.type == ItemID.Handgun || item.type == ItemID.PhoenixBlaster || item.type == ItemID.BlueMoon || item.type == ItemID.Muramasa || item.type == ItemID.Valor || item.type == ItemID.AquaScepter || item.type == ItemID.MagicMissile || item.type == ItemID.NightsEdge)
                    {
                        item.rare = -1;
                    }
                    if (item.type == ItemID.FloatingIslandFishingCrate)
                    {
                        item.rare = -1;
                    }
                    if (item.type == ItemID.ShadowKey)
                    {
                        item.rare = -1;
                    }
                }
                if (NPC.downedBoss2 == false)
                {
                    if (item.type == ItemID.FrogLeg || item.type == ItemID.FrogFlipper || item.type == ItemID.FrogWebbing || item.type == ItemID.FrogGear || item.type == ItemID.AmphibianBoots || item.type == ItemID.MeteorHelmet || item.type == ItemID.MeteorSuit || item.type == ItemID.MeteorLeggings)
                    {
                        item.rare = -1;
                    }
                    if (item.type == ItemID.StarCannon || item.type == ItemID.SpaceGun || item.type == ItemID.MeteorHamaxe)
                    {
                        item.rare = -1;
                    }
                    if (item.type == ItemID.MeteoriteBar)
                    {
                        item.rare = -1;
                    }
                }
            }
        }
        //Unused
        /*
        public override void OnConsumeItem(Item item, Player player)
        {
            base.OnConsumeItem(item, player);
            if (Main.getGoodWorld == true)
            {
                if (item.type == ItemID.FloatingIslandFishingCrate)
                {
                    if (Main.mouseRightRelease && player.ConsumeItem(ItemID.GoldenKey, false))
                    {
                        player.OpenFishingCrate(ItemID.FloatingIslandFishingCrate);
                    }
                }
            }
        }*/
    }
}
	
