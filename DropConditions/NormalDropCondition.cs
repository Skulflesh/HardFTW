using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.Localization;

namespace HardFTW.DropConditions
{
    public class NormalDropCondition : IItemDropRuleCondition
    {
        private static LocalizedText Description;

        public NormalDropCondition()
        {
            Description ??= Language.GetText("This is a Normal Mode drop rate");
        }

        public bool CanDrop(DropAttemptInfo info)
        {
            if (!Main.expertMode && !Main.masterMode)
            {
                return true;
            } else
            {
                return false;
            }

        }
        public bool CanShowItemDropInUI()
        {
            if (!Main.expertMode && !Main.masterMode)
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
	
