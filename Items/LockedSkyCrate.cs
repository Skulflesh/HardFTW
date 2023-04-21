using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
namespace HardFTW.Items
{
	public class LockedSkyCrate : ModItem
    {
		public override string Texture => "Terraria/Images/Item_" + ItemID.FloatingIslandFishingCrate;

        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.FloatingIslandFishingCrate);
        }

        public override void RightClick(Player player)
        {
            player.ConsumeItem(ItemID.GoldenKey);
            player.OpenFishingCrate(ItemID.FloatingIslandFishingCrate);
        }
        public override bool CanRightClick()
        {
	        return !Main.getGoodWorld || Main.LocalPlayer.HasItemInInventoryOrOpenVoidBag(ItemID.GoldenKey);
        }
	}
}