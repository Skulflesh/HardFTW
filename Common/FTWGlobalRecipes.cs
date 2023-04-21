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
using System;
using Terraria.Localization;

namespace HardFTW.Common
{
    public class FTWGlobalRecipes : ModSystem
    {
        public override void AddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                //Post Eye of Chitchat
                if (recipe.TryGetIngredient(ItemID.CrimtaneBar, out Item ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEoC"), () => NPC.downedBoss1 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.DemoniteBar, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEoC"), () => NPC.downedBoss1 && Main.getGoodWorld);
                }
                if (recipe.HasResult(ItemID.VilePowder) || recipe.HasResult(ItemID.ViciousPowder))
                {
                    recipe.AddDecraftCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEoC"), () => NPC.downedBoss1 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.DemoniteBar, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEoC"), () => NPC.downedBoss1 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.TatteredCloth, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEoC"), () => NPC.downedBoss1 && Main.getGoodWorld);
                }

                //Post Brain/EoW
                if (recipe.TryGetIngredient(ItemID.MeteoriteBar, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEvilBoss"), () => NPC.downedBoss2 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.TissueSample, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEvilBoss"), () => NPC.downedBoss2 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.ShadowScale, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEvilBoss"), () => NPC.downedBoss2 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.HellstoneBar, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostEvilBoss"), () => NPC.downedBoss2 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.BandofStarpower, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.PanicNecklace, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }

                //Post Queen Bee
                if (recipe.TryGetIngredient(ItemID.FrogLeg, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostBee"), () => NPC.downedQueenBee && Main.getGoodWorld);
                }

                //Post skeletron
                if (recipe.TryGetIngredient(ItemID.ShinyRedBalloon, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.LuckyHorseshoe, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.CelestialMagnet, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.SharkronBalloon, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.Handgun, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.MagicMissile, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
                if (recipe.TryGetIngredient(ItemID.Muramasa, out ingredient))
                {
                    recipe.AddCondition(Language.GetOrRegister("Mods.HardFTW.Conditions.PostSkele"), () => NPC.downedBoss3 && Main.getGoodWorld);
                }
            }
        }
    }
}

