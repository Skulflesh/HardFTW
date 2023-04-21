using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;
using HardFTW.Projectiles;

namespace HardFTW.Common
{
    public class FTWGlobalProjectile : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (Main.getGoodWorld)
            {
                TextureAssets.Projectile[ProjectileID.Bunny] = TextureAssets.Projectile[ModContent.ProjectileType<ExplBunnyPet>()];
            }
            base.OnSpawn(projectile, source);
        }
    }
}

