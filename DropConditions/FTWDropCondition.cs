using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.Chat;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace HardFTW.DropConditions
{
    public class FTWDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public FTWDropCondition()
        {
            Description ??= Language.GetText("This is a for the worthy drop rate");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return Main.getGoodWorld;
        }
        public bool CanShowItemDropInUI()
        {
            if (Main.getGoodWorld)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GetConditionDescription()
        {
            return Description.Value;
        }
    }
}
	
