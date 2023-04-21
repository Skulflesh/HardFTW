using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.Localization;

namespace HardFTW.NPCs.AI
{
    public static class CultistAI //idk
    {
        public static void Laugh(NPC npc)
        {
            SoundEngine.PlaySound(SoundID.Zombie105, npc.Center);
        }


        public static void CultistOverrideAI(NPC npc)
        {
            if (npc.ai[0] != -1.0 && Main.rand.Next(1000) == 0)
            {
                int numb = Main.rand.Next(0, 4);
                if (numb == 0) { SoundEngine.PlaySound(SoundID.Zombie88, npc.Center); }
                if (numb == 1) { SoundEngine.PlaySound(SoundID.Zombie89, npc.Center); }
                if (numb == 2) { SoundEngine.PlaySound(SoundID.Zombie90, npc.Center); }
                if (numb == 3) { SoundEngine.PlaySound(SoundID.Zombie91, npc.Center); }
            }

            bool expertMode = Main.expertMode;
            bool flag1 = npc.life <= npc.lifeMax / 2 || npc.life <= 10000;
            int num1 = 60;
            int damageForProjectiles1 = npc.GetAttackDamage_ForProjectiles(35f, 25f);
            int num2 = 10;
            int num3 = 5;
            int damageForProjectiles2 = npc.GetAttackDamage_ForProjectiles(30f, 20f);
            int num4 = 20;
            int damageForProjectiles3 = npc.GetAttackDamage_ForProjectiles(45f, 30f);
            int num5 = 30;
            int num6 = 2;
            int num7 = 20;
            int num8 = 3;
            bool flag2 = npc.type == NPCID.CultistBoss;
            bool flag3 = false;
            bool flag4 = false;

            if (flag1)
            {
                List<int> intList = new List<int>();
                for (int index = 0; index < 200; ++index)
                {
                    if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                        intList.Add(index);
                }
                npc.defense = (int)((double)npc.defDefense - intList.Count * 10f);
                num4 = 10;
            }
            if (!flag2)
            {
                if ((npc.ai[3] < 0.0 || !Main.npc[(int)npc.ai[3]].active ? 1 : Main.npc[(int)npc.ai[3]].type != NPCID.CultistBoss ? 1 : 0) != 0)
                {
                    npc.life = 0;
                    npc.HitEffect(0, 10.0);
                    npc.active = false;
                    return;
                }
                npc.ai[0] = Main.npc[(int)npc.ai[3]].ai[0];
                npc.ai[1] = Main.npc[(int)npc.ai[3]].ai[1];
                if (npc.ai[0] == 5.0)
                {
                    if (npc.justHit)
                    {
                        npc.life = 0;
                        npc.HitEffect(0, 10.0);
                        npc.active = false;
                        if (Main.netMode != 1)
                            NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                        NPC npc2 = Main.npc[(int)npc.ai[3]];
                        npc2.ai[0] = 6f;
                        npc2.ai[1] = 0.0f;
                        npc2.netUpdate = true;
                    }
                }
                else
                {
                    flag3 = true;
                    flag4 = true;
                }
            }
            else if (npc.ai[0] == 5.0 && npc.ai[1] >= 120.0 && npc.ai[1] < 420.0 && npc.justHit)
            {

                npc.ai[0] = 0.0f;
                npc.ai[1] = 0.0f;
                ++npc.ai[3];
                npc.velocity = Vector2.Zero;
                npc.netUpdate = true;
                List<int> intList = new List<int>();
                for (int index = 0; index < 200; ++index)
                {
                    if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                        intList.Add(index);
                }
                int num9 = 10;
                if (Main.expertMode)
                    num9 = 3;
                foreach (int number in intList)
                {
                    NPC npc2 = Main.npc[number];
                    if (npc2.localAI[1] == (double)npc.localAI[1] && num9 > 0)
                    {
                        --num9;
                        npc2.life = 0;
                        npc2.HitEffect(0, 10.0);
                        npc2.active = false;
                        if (Main.netMode != 1)
                        {
                            NetMessage.SendData(23, -1, -1, null, number);
                        }
                    }
                    else if (num9 > 0)
                    {
                        --num9;
                        npc2.life = 0;
                        npc2.HitEffect(0, 10.0);
                        npc2.active = false;
                    }
                }
                Main.projectile[(int)npc.ai[2]].ai[1] = -1f;
                Main.projectile[(int)npc.ai[2]].netUpdate = true;
            }
            Vector2 center1 = npc.Center;
            Player player = Main.player[npc.target];
            if (npc.target < 0 || npc.target == byte.MaxValue || player.dead || !player.active)
            {
                npc.TargetClosest(false);
                player = Main.player[npc.target];
                npc.netUpdate = true;
            }
            if (player.dead || (double)Vector2.Distance(player.Center, center1) > 5600.0)
            {
                npc.life = 0;
                npc.HitEffect(0, 10.0);
                npc.active = false;
                if (Main.netMode != 1)
                    NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f, 0.0f, 0.0f, 0, 0, 0);
                new List<int>() { npc.whoAmI };
                for (int index = 0; index < 200; ++index)
                {
                    if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                    {
                        Main.npc[index].life = 0;
                        Main.npc[index].HitEffect(0, 10.0);
                        Main.npc[index].active = false;
                        if (Main.netMode != 1)
                            NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f, 0.0f, 0.0f, 0, 0, 0);
                    }
                }
            }
            float num10 = npc.ai[3];
            if (npc.localAI[0] == 0.0)
            {
                SoundEngine.PlaySound(SoundID.Zombie89, npc.Center);
                npc.localAI[0] = 1f;
                npc.alpha = byte.MaxValue;
                npc.rotation = 0.0f;
                if (Main.netMode != 1)
                {
                    npc.ai[0] = -1f;
                    npc.netUpdate = true;
                }
            }
            if (npc.ai[0] == -1.0)
            {
                npc.alpha -= 5;
                if (npc.alpha < 0)
                    npc.alpha = 0;
                ++npc.ai[1];
                if (npc.ai[1] >= 420.0)
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    npc.netUpdate = true;
                }
                else if (npc.ai[1] > 360.0)
                {
                    npc.velocity = npc.velocity * 0.95f;
                    if (npc.localAI[2] != 13.0)
                        SoundEngine.PlaySound(SoundID.Zombie105, npc.Center);
                    npc.localAI[2] = 13f;
                }
                else if (npc.ai[1] > 300.0)
                {
                    npc.velocity = -Vector2.UnitY;
                    npc.localAI[2] = 10f;
                }
                else
                    npc.localAI[2] = npc.ai[1] <= 120.0 ? 0.0f : 1f;
                flag3 = true;
                flag4 = true;
            }
            if (npc.ai[0] == 0.0)
            {
                if (npc.ai[1] == 0.0)
                    npc.TargetClosest(false);
                npc.localAI[2] = 10f;
                int num9 = Math.Sign(player.Center.X - center1.X);
                if (num9 != 0)
                    npc.direction = npc.spriteDirection = num9;
                ++npc.ai[1];
                if (npc.ai[1] >= 40.0 & flag2)
                {
                    int num11 = 0;
                    if (flag1)
                    {
                        switch ((int)npc.ai[3])
                        {
                            case 0:
                                num11 = 0;
                                break;
                            case 1:
                                num11 = 1;
                                break;
                            case 2:
                                num11 = 0;
                                break;
                            case 3:
                                num11 = 5;
                                break;
                            case 4:
                                num11 = 0;
                                break;
                            case 5:
                                num11 = 3;
                                break;
                            case 6:
                                num11 = 0;
                                break;
                            case 7:
                                num11 = 5;
                                break;
                            case 8:
                                num11 = 0;
                                break;
                            case 9:
                                num11 = 2;
                                break;
                            case 10:
                                num11 = 0;
                                break;
                            case 11:
                                num11 = 3;
                                break;
                            case 12:
                                num11 = 0;
                                break;
                            case 13:
                                num11 = 4;
                                npc.ai[3] = -1f;
                                break;
                            default:
                                npc.ai[3] = -1f;
                                break;
                        }
                    }
                    else
                    {
                        switch ((int)npc.ai[3])
                        {
                            case 0:
                                num11 = 0;
                                break;
                            case 1:
                                num11 = 1;
                                break;
                            case 2:
                                num11 = 0;
                                break;
                            case 3:
                                num11 = 2;
                                break;
                            case 4:
                                num11 = 0;
                                break;
                            case 5:
                                num11 = 3;
                                break;
                            case 6:
                                num11 = 0;
                                break;
                            case 7:
                                num11 = 1;
                                break;
                            case 8:
                                num11 = 0;
                                break;
                            case 9:
                                num11 = 2;
                                break;
                            case 10:
                                num11 = 0;
                                break;
                            case 11:
                                num11 = 4;
                                npc.ai[3] = -1f;
                                break;
                            default:
                                npc.ai[3] = -1f;
                                break;
                        }
                    }
                    int maxValue = 6;
                    if (npc.life < npc.lifeMax / 3)
                        maxValue = 4;
                    if (npc.life < npc.lifeMax / 4)
                        maxValue = 3;
                    if (expertMode & flag1 && Main.rand.Next(maxValue) == 0 && num11 != 0 && num11 != 4 && num11 != 5 && NPC.CountNPCS(523) < 10)
                        num11 = 6;//
                    if (num11 == 0)
                    {
                        float num12 = (float)Math.Ceiling((double)(player.Center + new Vector2(0.0f, -100f) - center1).Length() / 50.0);
                        if ((double)num12 == 0.0)
                            num12 = 1f;
                        List<int> intList = new List<int>();
                        int num13 = 0;
                        intList.Add(npc.whoAmI);
                        for (int index = 0; index < 200; ++index)
                        {
                            if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                                intList.Add(index);
                        }
                        bool flag5 = intList.Count % 2 == 0;
                        foreach (int index in intList)
                        {
                            NPC npc1 = Main.npc[index];
                            Vector2 center2 = npc1.Center;
                            float num14 = (float)((num13 + flag5.ToInt() + 1) / 2 * 6.28318548202515 * 0.400000005960464) / intList.Count;
                            if (num13 % 2 == 1)
                                num14 *= -1f;
                            if (intList.Count == 1)
                                num14 = 0.0f;
                            Vector2 vector2_1 = new Vector2(0.0f, -1f).RotatedBy((double)num14, new Vector2()) * new Vector2(300f, 200f);
                            Vector2 vector2_2 = player.Center + vector2_1 - center2;
                            npc1.ai[0] = 1f;
                            npc1.ai[1] = num12 * 2f;
                            npc1.velocity = vector2_2 / num12;
                            if (npc.whoAmI >= npc1.whoAmI)
                            {
                                NPC npc2 = npc1;
                                npc2.position = npc2.position - npc1.velocity;
                            }
                            npc1.netUpdate = true;
                            ++num13;
                        }
                    }
                    if (num11 == 1)
                    {
                        npc.ai[0] = 3f;
                        npc.ai[1] = 0.0f;
                    }
                    else if (num11 == 2)
                    {
                        npc.ai[0] = 2f;
                        npc.ai[1] = 0.0f;
                    }
                    else if (num11 == 3)
                    {
                        npc.ai[0] = 4f;
                        npc.ai[1] = 0.0f;
                    }
                    else if (num11 == 4)
                    {
                        npc.ai[0] = 5f;
                        npc.ai[1] = 0.0f;
                    }
                    if (num11 == 5)
                    {
                        npc.ai[0] = 7f;
                        npc.ai[1] = 0.0f;
                    }
                    if (num11 == 6)
                    {
                        npc.ai[0] = 8f;
                        npc.ai[1] = 0.0f;
                    }
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 1.0)
            {
                flag3 = true;
                npc.localAI[2] = 10f;
                if ((int)npc.ai[1] % 2.0 != 0.0 && npc.ai[1] != 1.0)
                    npc.position = npc.position - npc.velocity;
                --npc.ai[1];
                if (npc.ai[1] <= 0.0)
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 2.0)//Ice Mist
            {
                npc.localAI[2] = 11f;
                Vector2 vec1 = Vector2.Normalize(player.Center - center1);
                if (vec1.HasNaNs())
                    vec1 = new Vector2(npc.direction, 0.0f);
                if (npc.ai[1] >= 4.0 & flag2 && (int)(npc.ai[1] - 4.0) % num1 == 0)
                {
                    if (Main.netMode != 1)
                    {
                        List<int> intList = new List<int>();
                        for (int index = 0; index < 200; ++index)
                        {
                            if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                                intList.Add(index);
                        }
                        foreach (int index1 in intList)
                        {
                            NPC npc2 = Main.npc[index1];
                            Vector2 center2 = npc2.Center;
                            int num9 = Math.Sign(player.Center.X - center2.X);
                            if (num9 != 0)
                                npc2.direction = npc2.spriteDirection = num9;
                            if (Main.netMode != 1)
                            {
                                Vector2 vec2 = Vector2.Normalize(player.Center - center2 + player.velocity * 20f);
                                if (vec2.HasNaNs())
                                    vec2 = new Vector2(npc.direction, 0.0f);
                                Vector2 vector2_1 = center2 + new Vector2(npc.direction * 30, 12f);
                                for (int index2 = 0; index2 < 1; ++index2)
                                {
                                    Vector2 vector2_2 = (vec2 * (float)(6.0 + Main.rand.NextDouble() * 4.0)).RotatedByRandom(0.523598790168762);
                                    Projectile.NewProjectile(npc.GetSource_FromAI(), vector2_1, vector2_2, 468, 18, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                                }
                            }
                        }
                    }
                    if (Main.netMode != 1)
                    {
                        Vector2 vec2 = Vector2.Normalize(player.Center - center1 + player.velocity * 20f);
                        if (vec2.HasNaNs())
                            vec2 = new Vector2(npc.direction, 0.0f);
                        Vector2 vector2_1 = npc.Center + new Vector2(npc.direction * 30, 12f);
                        for (int index = 0; index < 1; ++index)
                        {
                            Vector2 vector2_2 = vec2 * 4f;
                            Projectile.NewProjectile(npc.GetSource_FromAI(), vector2_1, vector2_2, 464, damageForProjectiles1, 0.0f, Main.myPlayer, 0.0f, 1f);
                        }
                    }
                }
                ++npc.ai[1];
                if (npc.ai[1] >= (double)(4 + num1))
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 3.0)//Fireball Attack
            {
                npc.localAI[2] = 11f;
                Vector2 vec1 = Vector2.Normalize(player.Center - center1);
                if (vec1.HasNaNs())
                    vec1 = new Vector2(npc.direction, 0.0f);
                if (npc.ai[1] >= 4.0 & flag2 && (int)(npc.ai[1] - 4.0) % num2 == 0)
                {
                    if ((int)(npc.ai[1] - 4.0) / num2 == 2)
                    {
                        List<int> intList = new List<int>();
                        for (int index = 0; index < 200; ++index)
                        {
                            if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                                intList.Add(index);
                        }
                        if (Main.netMode != 1)
                        {
                            foreach (int index1 in intList)
                            {
                                NPC npc2 = Main.npc[index1];
                                Vector2 center2 = npc2.Center;
                                int num9 = Math.Sign(player.Center.X - center2.X);
                                if (num9 != 0)
                                    npc.direction = npc2.spriteDirection = num9;
                                if (Main.netMode != 1)
                                {
                                    Vector2 vec2 = Vector2.Normalize(player.Center - center2 + player.velocity * 20f);
                                    if (vec2.HasNaNs())
                                        vec2 = new Vector2(npc.direction, 0.0f);
                                    Vector2 vector2_1 = center2 + new Vector2(npc.direction * 30, 12f);
                                    for (int index2 = 0; index2 < 1; ++index2)
                                    {
                                        Vector2 vector2_2 = (vec2 * (float)(6.0 + Main.rand.NextDouble() * 4.0)).RotatedByRandom(0.523598790168762);
                                        Projectile.NewProjectile(npc.GetSource_FromAI(), vector2_1, vector2_2, 468, 18, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                                    }
                                }
                            }
                        }
                    }
                    int num11 = Math.Sign(player.Center.X - center1.X);
                    if (num11 != 0)
                        npc.direction = npc.spriteDirection = num11;
                    if (Main.netMode != 1)
                    {
                        Vector2 vec2 = Vector2.Normalize(player.Center - center1 + player.velocity * 20f);
                        if (vec2.HasNaNs())
                            vec2 = new Vector2(npc.direction, 0.0f);
                        Vector2 vector2_1 = npc.Center + new Vector2(npc.direction * 30, 12f);
                        for (int index = 0; index < 1; ++index)
                        {
                            Vector2 vector2_2 = (vec2 * (float)(6.0 + Main.rand.NextDouble() * 4.0)).RotatedByRandom(0.523598790168762);
                            Projectile.NewProjectile(npc.GetSource_FromAI(), vector2_1, vector2_2, 467, damageForProjectiles2, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        }
                    }
                }
                ++npc.ai[1];
                if (npc.ai[1] >= (double)(4 + num2 * num3))
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 4.0) //Lightning Ball Attack
            {
                npc.localAI[2] = !flag2 ? 11f : 12f;
                if (npc.ai[1] == 20.0 & flag2 && Main.netMode != 1)
                {
                    List<int> intList = new List<int>();
                    for (int index = 0; index < 200; ++index)
                    {
                        if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                            intList.Add(index);
                    }
                    foreach (int index1 in intList)
                    {
                        NPC npc2 = Main.npc[index1];
                        Vector2 center2 = npc2.Center;
                        int num9 = Math.Sign(player.Center.X - center2.X);
                        if (num9 != 0)
                            npc2.direction = npc2.spriteDirection = num9;
                        if (Main.netMode != 1)
                        {
                            Vector2 vec = Vector2.Normalize(player.Center - center2 + player.velocity * 20f);
                            if (vec.HasNaNs())
                                vec = new Vector2(npc.direction, 0.0f);
                            Vector2 vector2_1 = center2 + new Vector2(npc.direction * 30, 12f);
                            for (int index2 = 0; index2 < 1; ++index2)
                            {
                                Vector2 vector2_2 = (vec * (float)(6.0 + Main.rand.NextDouble() * 4.0)).RotatedByRandom(0.523598790168762);
                                Projectile.NewProjectile(npc.GetSource_FromAI(), vector2_1, vector2_2, 468, 18, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                            }
                        }
                    }
                    if ((int)(npc.ai[1] - 20.0) % num4 == 0)
                    {
                        Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center.X, npc.Center.Y - 100f, 0.0f, 0.0f, 465, damageForProjectiles3, 0.0f, Main.myPlayer, 0.0f, npc.whoAmI);
                    }
                }
                ++npc.ai[1];
                if (npc.ai[1] >= (double)(20 + num4))
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 5.0) //Summon circle
            {
                npc.localAI[2] = 10f;
                if (Vector2.Normalize(player.Center - center1).HasNaNs())
                {
                    Vector2 vector2_1 = new Vector2(npc.direction, 0.0f);
                }
                if (npc.ai[1] >= 0.0 && npc.ai[1] < 30.0)
                {
                    flag3 = true;
                    flag4 = true;
                    npc.alpha = (int)((npc.ai[1] - 0.0) / 30.0 * byte.MaxValue);
                }
                else if (npc.ai[1] >= 30.0 && npc.ai[1] < 90.0)
                {
                    if (((npc.ai[1] != 30.0 ? 0 : Main.netMode != 1 ? 1 : 0) & (flag2 ? 1 : 0)) != 0)
                    {
                        ++npc.localAI[1];
                        Vector2 spinningpoint = new Vector2(180f, 0.0f);
                        List<int> intList = new List<int>();
                        for (int index = 0; index < 200; ++index)
                        {
                            if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                                intList.Add(index);
                        }
                        int num9 = 6 - intList.Count;
                        if (num9 > 2)
                            num9 = 2;
                        int length = intList.Count + num9 + 1;
                        float[] numArray = new float[length];
                        for (int index = 0; index < numArray.Length; ++index)
                            numArray[index] = Vector2.Distance(npc.Center + spinningpoint.RotatedBy(index * 6.28318548202515 / length - 1.57079637050629, new Vector2()), player.Center);
                        int index1 = 0;
                        for (int index2 = 1; index2 < numArray.Length; ++index2)
                        {
                            if (numArray[index1] > (double)numArray[index2])
                                index1 = index2;
                        }
                        int num11 = index1 >= length / 2 ? index1 - length / 2 : index1 + length / 2;
                        int num12 = num9;
                        for (int index2 = 0; index2 < numArray.Length; ++index2)
                        {
                            if (num11 != index2)
                            {
                                Vector2 vector2_2 = npc.Center + spinningpoint.RotatedBy(index2 * 6.28318548202515 / length - 1.57079637050629, new Vector2());
                                if (num12-- > 0)
                                {
                                    int index3 = NPC.NewNPC(npc.GetSource_FromAI(), (int)vector2_2.X, (int)vector2_2.Y + npc.height / 2, NPCID.CultistBossClone, npc.whoAmI, 0.0f, 0.0f, 0.0f, 0.0f, byte.MaxValue);
                                    Main.npc[index3].ai[3] = npc.whoAmI;
                                    Main.npc[index3].netUpdate = true;
                                    Main.npc[index3].localAI[1] = npc.localAI[1];
                                }
                                else
                                {
                                    int number = intList[-num12 - 1];
                                    Main.npc[number].Center = vector2_2;
                                    NetMessage.SendData(23, -1, -1, null, number, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                                }
                            }
                        }
                        npc.ai[2] = Projectile.NewProjectile(npc.GetSource_FromAI(), npc.Center.X, npc.Center.Y, 0.0f, 0.0f, 490, 0, 0.0f, Main.myPlayer, 0.0f, npc.whoAmI);
                        npc.Center = npc.Center + spinningpoint.RotatedBy(num11 * 6.28318548202515 / length - 1.57079637050629, new Vector2());
                        npc.netUpdate = true;
                        intList.Clear();

                    }

                    flag3 = true;
                    flag4 = true;
                    npc.alpha = byte.MaxValue;
                    if (flag2)
                    {
                        Vector2 vector2_2 = Main.projectile[(int)npc.ai[2]].Center - npc.Center;
                        if (vector2_2 == Vector2.Zero)
                            vector2_2 = -Vector2.UnitY;
                        vector2_2.Normalize();
                        npc.localAI[2] = (double)Math.Abs(vector2_2.Y) >= 0.769999980926514 ? vector2_2.Y >= 0.0 ? 10f : 12f : 11f;
                        int num9 = Math.Sign(vector2_2.X);
                        if (num9 != 0)
                            npc.direction = npc.spriteDirection = num9;
                    }
                    else
                    {
                        Vector2 vector2_2 = Main.projectile[(int)Main.npc[(int)npc.ai[3]].ai[2]].Center - npc.Center;
                        if (vector2_2 == Vector2.Zero)
                            vector2_2 = -Vector2.UnitY;
                        vector2_2.Normalize();
                        npc.localAI[2] = (double)Math.Abs(vector2_2.Y) >= 0.769999980926514 ? vector2_2.Y >= 0.0 ? 10f : 12f : 11f;
                        int num9 = Math.Sign(vector2_2.X);
                        if (num9 != 0)
                            npc.direction = npc.spriteDirection = num9;
                    }
                }
                else if (npc.ai[1] >= 90.0 && npc.ai[1] < 120.0)
                {
                    flag3 = true;
                    flag4 = true;
                    npc.alpha = byte.MaxValue - (int)((npc.ai[1] - 90.0) / 30.0 * byte.MaxValue);
                }
                else if (npc.ai[1] >= 120.0 && npc.ai[1] < 420.0)
                {
                    npc.alpha = 0;
                    if (flag2)
                    {
                        flag4 = true;
                        Vector2 vector2_2 = Main.projectile[(int)npc.ai[2]].Center - npc.Center;
                        if (vector2_2 == Vector2.Zero)
                            vector2_2 = -Vector2.UnitY;
                        vector2_2.Normalize();
                        if (flag1)
                        {
                            npc.ai[0] = 6f;
                            npc.ai[1] = 0.0f;
                            List<int> intList = new List<int>();
                            for (int index = 0; index < 200; ++index)
                            {
                                if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                                {
                                    Main.npc[index].ai[0] = 6f;
                                    Main.npc[index].ai[1] = 0f;
                                }
                            }
                            if (Main.netMode != 1)
                                NetMessage.SendData(23, -1, -1, null, npc.whoAmI, 0.0f, 0.0f, 0.0f, 0, 0, 0);
                        }
                        else
                        {
                            flag4 = true;
                            npc.localAI[2] = (double)Math.Abs(vector2_2.Y) >= 0.769999980926514 ? vector2_2.Y >= 0.0 ? 10f : 12f : 11f;
                        }
                        int num9 = Math.Sign(vector2_2.X);
                        if (num9 != 0)
                            npc.direction = npc.spriteDirection = num9;
                    }
                    else
                    {
                        Vector2 vector2_2 = Main.projectile[(int)Main.npc[(int)npc.ai[3]].ai[2]].Center - npc.Center;
                        if (vector2_2 == Vector2.Zero)
                            vector2_2 = -Vector2.UnitY;
                        vector2_2.Normalize();
                        if (flag1)
                        {
                            flag4 = false;
                            flag3 = true;

                        }
                        else
                        {
                            flag4 = true;
                            npc.localAI[2] = (double)Math.Abs(vector2_2.Y) >= 0.769999980926514 ? vector2_2.Y >= 0.0 ? 10f : 12f : 11f;
                        }
                        int num9 = Math.Sign(vector2_2.X);
                        if (num9 != 0)
                            npc.direction = npc.spriteDirection = num9;
                    }

                }
                ++npc.ai[1];
                if (npc.ai[1] >= 420.0)
                {
                    if (flag1)
                    {
                        flag3 = true;
                        npc.localAI[2] = 0f;
                    }
                    flag4 = true;
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 6.0)
            {
                flag4 = true;
                if (npc.localAI[2] != 13.0)
                    SoundEngine.PlaySound(SoundID.Zombie105, npc.Center);
                npc.localAI[2] = 13f;
                ++npc.ai[1];
                if (npc.ai[1] >= 200.0)
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 7.0)//Ancient Light
            {
                npc.localAI[2] = 11f;
                Vector2 vec1 = Vector2.Normalize(player.Center - center1);
                if (vec1.HasNaNs())
                    vec1 = new Vector2(npc.direction, 0.0f);
                if (npc.ai[1] >= 4.0 & flag2 && (int)(npc.ai[1] - 4.0) % num5 == 0)
                {
                    if ((int)(npc.ai[1] - 4.0) / num5 == 2)
                    {
                        List<int> intList = new List<int>();
                        for (int index = 0; index < 200; ++index)
                        {
                            if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                                intList.Add(index);
                        }
                        foreach (int index1 in intList)
                        {
                            NPC npc2 = Main.npc[index1];
                            Vector2 center2 = npc2.Center;
                            int num9 = Math.Sign(player.Center.X - center2.X);
                            if (num9 != 0)
                                npc2.direction = npc2.spriteDirection = num9;
                            if (Main.netMode != 1)
                            {
                                Vector2 vec2 = Vector2.Normalize(player.Center - center2 + player.velocity * 20f);
                                if (vec2.HasNaNs())
                                    vec2 = new Vector2(npc.direction, 0.0f);
                                Vector2 vector2_1 = center2 + new Vector2(npc.direction * 30, 12f);
                                for (int index2 = 0; index2 < 5.0; ++index2)
                                {
                                    Vector2 vector2_2 = (vec2 * (float)(6.0 + Main.rand.NextDouble() * 4.0)).RotatedByRandom(1.25663709640503);
                                    Projectile.NewProjectile(npc.GetSource_FromAI(), vector2_1, vector2_2, 468, 18, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                                }
                            }
                        }
                    }
                    int num11 = Math.Sign(player.Center.X - center1.X);
                    if (num11 != 0)
                        npc.direction = npc.spriteDirection = num11;
                    if (Main.netMode != 1)
                    {
                        Vector2 vec2 = Vector2.Normalize(player.Center - center1 + player.velocity * 20f);
                        if (vec2.HasNaNs())
                            vec2 = new Vector2(npc.direction, 0.0f);
                        Vector2 vector2_1 = npc.Center + new Vector2(npc.direction * 30, 12f);
                        float num9 = 8f;
                        float num12 = 0.2513274f;
                        for (int index1 = 0; index1 < 5.0; ++index1)
                        {
                            Vector2 vector2_2 = (vec2 * num9).RotatedBy((double)num12 * index1 - (1.25663709640503 - (double)num12) / 2.0, new Vector2());
                            float ai1 = (float)(((double)Main.rand.NextFloat() - 0.5) * 0.300000011920929 * 6.28318548202515 / 60.0);
                            int index2 = NPC.NewNPC(npc.GetSource_FromAI(), (int)vector2_1.X, (int)vector2_1.Y + 7, 522, 0, 0.0f, ai1, vector2_2.X, vector2_2.Y, byte.MaxValue);
                            Main.npc[index2].velocity = vector2_2;
                        }
                    }
                }
                ++npc.ai[1];
                if (npc.ai[1] >= (double)(4 + num5 * num6))
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            else if (npc.ai[0] == 8.0)//Ancient Dooom
            {
                npc.localAI[2] = 13f;
                if (npc.ai[1] >= 4.0 & flag2 && (int)(npc.ai[1] - 4.0) % num7 == 0)
                {
                    List<int> intList = new List<int>();
                    for (int index = 0; index < 200; ++index)
                    {
                        if (Main.npc[index].active && Main.npc[index].type == NPCID.CultistBossClone && Main.npc[index].ai[3] == (double)npc.whoAmI)
                            intList.Add(index);
                    }
                    int num9 = intList.Count + 1;
                    if (num9 > 3)
                        num9 = 3;
                    int num11 = Math.Sign(player.Center.X - center1.X);
                    if (num11 != 0)
                        npc.direction = npc.spriteDirection = num11;
                    if (Main.netMode != 1)
                    {
                        for (int index1 = 0; index1 < num9; ++index1)
                        {
                            Point tileCoordinates1 = npc.Center.ToTileCoordinates();
                            Point tileCoordinates2 = Main.player[npc.target].Center.ToTileCoordinates();
                            Vector2 vector2 = Main.player[npc.target].Center - npc.Center;
                            int num12 = 20;
                            int num13 = 3;
                            int num14 = 7;
                            int num15 = 2;
                            int num16 = 0;
                            bool flag5 = false;
                            if ((double)vector2.Length() > 2000.0)
                                flag5 = true;
                            while (!flag5 && num16 < 100)
                            {
                                ++num16;
                                int index2 = Main.rand.Next(tileCoordinates2.X - num12, tileCoordinates2.X + num12 + 1);
                                int index3 = Main.rand.Next(tileCoordinates2.Y - num12, tileCoordinates2.Y + num12 + 1);
                                if ((index3 < tileCoordinates2.Y - num14 || index3 > tileCoordinates2.Y + num14 || index2 < tileCoordinates2.X - num14 || index2 > tileCoordinates2.X + num14) && (index3 < tileCoordinates1.Y - num13 || index3 > tileCoordinates1.Y + num13 || index2 < tileCoordinates1.X - num13 || index2 > tileCoordinates1.X + num13) && (!Main.tile[index2, index3].HasTile || Main.tile[index2, index3].IsActuated))
                                {
                                    bool flag6 = true;
                                    if (flag6 && Collision.SolidTiles(index2 - num15, index2 + num15, index3 - num15, index3 + num15))
                                        flag6 = false;
                                    if (flag6)
                                    {
                                        NPC.NewNPC(npc.GetSource_FromAI(), index2 * 16 + 8, index3 * 16 + 8, 523, 0, npc.whoAmI, 0.0f, 0.0f, 0.0f, byte.MaxValue);
                                        break; // Ancient Doom attack
                                    }
                                }
                            }
                        }
                    }
                }
                ++npc.ai[1];
                if (npc.ai[1] >= (double)(4 + num7 * num8))
                {
                    npc.ai[0] = 0.0f;
                    npc.ai[1] = 0.0f;
                    ++npc.ai[3];
                    npc.velocity = Vector2.Zero;
                    npc.netUpdate = true;
                }
            }
            if (!flag2)
                npc.ai[3] = num10;
            npc.dontTakeDamage = flag3;
            npc.chaseable = !flag4;
        }


    }
}
/*
*/