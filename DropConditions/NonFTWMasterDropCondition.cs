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
    public class NonFTWMasterDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public NonFTWMasterDropCondition()
        {
            Description ??= Language.GetText("This is a non for the worthy drop rate");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            return !Main.getGoodWorld && Main.masterMode;
        }
        public bool CanShowItemDropInUI()
        {
            if (!Main.getGoodWorld && Main.masterMode)
            {
                return true;
            } else
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
	
