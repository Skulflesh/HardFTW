using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.ModLoader.Utilities;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HardFTW.DropConditions;
using Microsoft.CodeAnalysis;
using Terraria.WorldBuilding;
using HardFTW.Items;
using HardFTW.NPCs.AI;
using HardFTW.NPCs;
using Terraria.GameContent;

namespace HardFTW
{
    public class HardFTW : Mod
    {
        public override void Load()
        {
            AddBossHeadTexture("HardFTW/NPCs/PhantasmDragon_Head_Boss", NPCID.CultistDragonHead);
            base.Load();
        }
    }
}