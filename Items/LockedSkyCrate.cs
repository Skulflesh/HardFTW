using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Utilities;
using System;
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
	public class LockedSkyCrate : ModItem
	{
		public override string Texture => "Terraria/Images/Item_" + ItemID.FloatingIslandFishingCrate;
		public override void SetStaticDefaults()
		{
			Tooltip.SetDefault(@"Beta Item, does not work properly, uninmplemented.
Requires a Golden Key.");
			DisplayName.SetDefault("Locked Sky Crate");
		}

		public override void SetDefaults()
		{
			Item.CloneDefaults(ItemID.FloatingIslandFishingCrate);
		}

		public override void RightClick(Player player)
		{
			player.OpenFishingCrate(ItemID.FloatingIslandFishingCrate);
		}

		public override bool CanRightClick()
		{
			return !Main.getGoodWorld || Main.LocalPlayer.ConsumeItem(ItemID.GoldenKey);
		}
	}
}