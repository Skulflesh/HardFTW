using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using HardFTW.DropConditions;
using ReLogic.Utilities;
using System;
using System.Collections.Generic;
using Terraria.Audio;
using Terraria.Chat;
using Terraria.Enums;
using Terraria.GameContent;
using Terraria.GameContent.Achievements;
using Terraria.GameContent.Creative;
using Terraria.GameContent.Drawing;
using Terraria.GameContent.Events;
using Terraria.GameContent.RGB;
using Terraria.GameContent.UI;
using Terraria.Localization;
using Terraria.Utilities;
using Terraria.WorldBuilding;

namespace HardFTW.NPCs.AI
{
    public static class DragonAI2 //idk
    {
        
        public static void DragonOverrideAI(NPC npc)
        {
            if (npc.type == 454 && npc.localAI[3] == 0f)
            {
                SoundEngine.PlaySound(SoundID.Item119, npc.position);
                npc.localAI[3] = 1f;
            }


            if (npc.type == 454 || npc.type >= 454 && npc.type <= 459)
            {
                npc.dontTakeDamage = npc.alpha > 0;
                if (npc.type == 454 || npc.type != 454 && Main.npc[(int)npc.ai[1]].alpha < 85)
                {
                    if (npc.dontTakeDamage)
                    {
                        for (int j = 0; j < 2; j++)
                        {
                            int num2 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 228, 0f, 0f, 100, default, 2f);
                            Main.dust[num2].noGravity = true;
                            Main.dust[num2].noLight = true;
                        }
                    }
                    npc.alpha -= 42;
                    if (npc.alpha < 0)
                    {
                        npc.alpha = 0;
                    }
                }
            }
            bool flag = false;
            float num11 = 0.2f;
            if (npc.ai[3] <= 0f)
            {
                npc.realLife = (int)npc.ai[3];
            }
            if (npc.target < 0 || npc.target == 255 || Main.player[npc.target].dead || flag && Main.player[npc.target].position.Y < Main.worldSurface * 16.0)
            {
                npc.TargetClosest();
            }
            if (Main.player[npc.target].dead || flag && Main.player[npc.target].position.Y < Main.worldSurface * 16.0)
            {
                npc.EncourageDespawn(300);
                if (flag)
                {
                    npc.velocity.Y += num11;
                }
            }

            if (Main.netMode != 1)
            {
                if (npc.type == 454 && npc.ai[0] == 0f)
                {
                    npc.ai[3] = npc.whoAmI;
                    npc.realLife = npc.whoAmI;
                    int num15 = 0;
                    int num16 = npc.whoAmI;
                    for (int n = 0; n < 30; n++)
                    {
                        int num17 = 456;
                        if ((n - 2) % 4 == 0 && n < 26)
                        {
                            num17 = 455;
                        }
                        else
                        {
                            switch (n)
                            {
                                case 27:
                                    num17 = 457;
                                    break;
                                case 28:
                                    num17 = 458;
                                    break;
                                case 29:
                                    num17 = 459;
                                    break;
                            }
                        }
                        num15 = NPC.NewNPC(npc.GetSource_FromAI(), (int)(npc.position.X + npc.width / 2), (int)(npc.position.Y + npc.height), num17, npc.whoAmI);
                        Main.npc[num15].ai[3] = npc.whoAmI;
                        Main.npc[num15].realLife = npc.whoAmI;
                        Main.npc[num15].ai[1] = num16;
                        Main.npc[num15].CopyInteractions(npc);
                        Main.npc[num16].ai[0] = num15;
                        NetMessage.SendData(23, -1, -1, null, num15);
                        num16 = num15;
                    }
                }
                switch (npc.type)
                {
                    case 455:
                    case 456:
                    case 457:
                    case 458:
                    case 459:
                        if (!Main.npc[(int)npc.ai[1]].active || Main.npc[(int)npc.ai[1]].aiStyle != npc.aiStyle)
                        {
                            npc.life = 0;
                            npc.HitEffect();
                            npc.checkDead();
                            npc.active = false;
                            NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f);
                            return;
                        }
                        break;
                }
                switch (npc.type)
                {
                    case 454:
                    case 455:
                    case 456:
                    case 457:
                    case 458:
                        if (!Main.npc[(int)npc.ai[0]].active || Main.npc[(int)npc.ai[0]].aiStyle != npc.aiStyle)
                        {
                            npc.life = 0;
                            npc.HitEffect();
                            npc.checkDead();
                            npc.active = false;
                            NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f);
                            return;
                        }
                        break;
                }
                if (!npc.active && Main.netMode == 2)
                {
                    NetMessage.SendData(28, -1, -1, null, npc.whoAmI, -1f);
                }
            }


            int num44 = (int)(npc.position.X / 16f) - 1;
            int num45 = (int)((npc.position.X + npc.width) / 16f) + 2;
            int num46 = (int)(npc.position.Y / 16f) - 1;
            int num47 = (int)((npc.position.Y + npc.height) / 16f) + 2;
            if (num44 < 0)
            {
                num44 = 0;
            }
            if (num45 > Main.maxTilesX)
            {
                num45 = Main.maxTilesX;
            }
            if (num46 < 0)
            {
                num46 = 0;
            }
            if (num47 > Main.maxTilesY)
            {
                num47 = Main.maxTilesY;
            }

            bool flag2 = false;
            if (npc.type >= 454 && npc.type <= 459)
            {
                flag2 = true;
            }
            if (!flag2 && (npc.type == 7 || npc.type == 10 || npc.type == 13 || npc.type == 39 || npc.type == 95 || npc.type == 98 || npc.type == 117 || npc.type == 375 || npc.type == 454 || npc.type == 510 || npc.type == 513 || npc.type == 621))
            {
                Rectangle rectangle = new Rectangle((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height);
                int num50 = 1000;
                bool flag3 = true;
                for (int num51 = 0; num51 < 255; num51++)
                {
                    if (Main.player[num51].active)
                    {
                        Rectangle rectangle2 = new Rectangle((int)Main.player[num51].position.X - num50, (int)Main.player[num51].position.Y - num50, num50 * 2, num50 * 2);
                        if (rectangle.Intersects(rectangle2))
                        {
                            flag3 = false;
                            break;
                        }
                    }
                }
                if (flag3)
                {
                    flag2 = true;
                }
            }
            if (npc.type >= 87 && npc.type <= 92 || npc.type >= 454 && npc.type <= 459 || npc.type >= 621 && npc.type <= 623)
            {
                if (npc.velocity.X < 0f)
                {
                    npc.spriteDirection = 1;
                }
                else if (npc.velocity.X > 0f)
                {
                    npc.spriteDirection = -1;
                }
            }


            float num52 = 8f;
            float num53 = 0.07f;
            if (npc.type == 454)
            {
                num52 = 20f;
                num53 = 0.55f;
            }
            Vector2 vector5 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
            float num55 = Main.player[npc.target].position.X + Main.player[npc.target].width / 2;
            float num56 = Main.player[npc.target].position.Y + Main.player[npc.target].height / 2;
            num55 = (int)(num55 / 16f) * 16;
            num56 = (int)(num56 / 16f) * 16;
            vector5.X = (int)(vector5.X / 16f) * 16;
            vector5.Y = (int)(vector5.Y / 16f) * 16;
            num55 -= vector5.X;
            num56 -= vector5.Y;


            float num68 = (float)Math.Sqrt(num55 * num55 + num56 * num56);
            if (npc.ai[1] > 0f && npc.ai[1] < Main.npc.Length)
            {
                try
                {
                    vector5 = new Vector2(npc.position.X + npc.width * 0.5f, npc.position.Y + npc.height * 0.5f);
                    num55 = Main.npc[(int)npc.ai[1]].position.X + Main.npc[(int)npc.ai[1]].width / 2 - vector5.X;
                    num56 = Main.npc[(int)npc.ai[1]].position.Y + Main.npc[(int)npc.ai[1]].height / 2 - vector5.Y;
                }
                catch
                {
                }
                npc.rotation = (float)Math.Atan2(num56, num55) + 1.57f;
                num68 = (float)Math.Sqrt(num55 * num55 + num56 * num56);
                int num69 = npc.width;
                if (npc.type >= 454 && npc.type <= 459)
                {
                    num69 = 36;
                }
                num68 = (num68 - num69) / num68;
                num55 *= num68;
                num56 *= num68;
                npc.velocity = Vector2.Zero;
                npc.position.X += num55;
                npc.position.Y += num56;
                if (npc.type >= 454 && npc.type <= 459)
                {
                    if (num55 < 0f)
                    {
                        npc.spriteDirection = 1;
                    }
                    else if (num55 > 0f)
                    {
                        npc.spriteDirection = -1;
                    }
                }
            }
            else
            {
                if (!flag2)
                {
                    npc.TargetClosest();
                    if (npc.type == 39 && npc.velocity.Y < 0f)
                    {
                        npc.velocity.Y += 0.08f;
                    }
                    else
                    {
                        npc.velocity.Y += 0.11f;
                    }
                    if (npc.velocity.Y > num52)
                    {
                        npc.velocity.Y = num52;
                    }
                    if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num52 * 0.4)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X -= num53 * 1.1f;
                        }
                        else
                        {
                            npc.velocity.X += num53 * 1.1f;
                        }
                    }
                    else if (npc.velocity.Y == num52)
                    {
                        if (npc.velocity.X < num55)
                        {
                            npc.velocity.X += num53;
                        }
                        else if (npc.velocity.X > num55)
                        {
                            npc.velocity.X -= num53;
                        }
                    }
                    else if (npc.velocity.Y > 4f)
                    {
                        if (npc.velocity.X < 0f)
                        {
                            npc.velocity.X += num53 * 0.9f;
                        }
                        else
                        {
                            npc.velocity.X -= num53 * 0.9f;
                        }
                    }
                }
                else
                {
                    num68 = (float)Math.Sqrt(num55 * num55 + num56 * num56);
                    float num71 = Math.Abs(num55);
                    float num72 = Math.Abs(num56);
                    float num73 = num52 / num68;
                    num55 *= num73;
                    num56 *= num73;
                    bool flag4 = false;
                    if (Main.player[npc.target].dead)
                    {
                        flag4 = true;
                    }
                    if (flag4)
                    {
                        bool flag5 = true;
                        for (int num74 = 0; num74 < 255; num74++)
                        {
                            if (Main.player[num74].active && !Main.player[num74].dead && Main.player[num74].ZoneCorrupt)
                            {
                                flag5 = false;
                            }
                        }
                        if (flag5)
                        {
                            if (Main.netMode != 1 && (double)(npc.position.Y / 16f) > (Main.rockLayer + Main.maxTilesY) / 2.0)
                            {
                                npc.active = false;
                                int num75 = (int)npc.ai[0];
                                while (num75 > 0 && num75 < 200 && Main.npc[num75].active && Main.npc[num75].aiStyle == npc.aiStyle)
                                {
                                    int num76 = (int)Main.npc[num75].ai[0];
                                    Main.npc[num75].active = false;
                                    npc.life = 0;
                                    if (Main.netMode == 2)
                                    {
                                        NetMessage.SendData(23, -1, -1, null, num75);
                                    }
                                    num75 = num76;
                                }
                                if (Main.netMode == 2)
                                {
                                    NetMessage.SendData(23, -1, -1, null, npc.whoAmI);
                                }
                            }
                            num55 = 0f;
                            num56 = num52;
                        }
                    }
                    bool flag6 = false;
                    if (npc.type == 454)
                    {
                        float num77 = 300f;
                        if ((npc.velocity.X > 0f && num55 < 0f || npc.velocity.X < 0f && num55 > 0f || npc.velocity.Y > 0f && num56 < 0f || npc.velocity.Y < 0f && num56 > 0f) && Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) > num53 / 2f && num68 < num77)
                        {
                            flag6 = true;
                            if (Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y) < num52)
                            {
                                npc.velocity *= 1.1f;
                            }
                        }
                        if (npc.position.Y > Main.player[npc.target].position.Y || Main.player[npc.target].dead)
                        {
                            flag6 = true;
                            if (Math.Abs(npc.velocity.X) < num52 / 2f)
                            {
                                if (npc.velocity.X == 0f)
                                {
                                    npc.velocity.X -= npc.direction;
                                }
                                npc.velocity.X *= 1.1f;
                            }
                            else if (npc.velocity.Y > 0f - num52)
                            {
                                npc.velocity.Y -= num53;
                            }
                        }
                    }
                    if (!flag6)
                    {
                        if (npc.velocity.X > 0f && num55 > 0f || npc.velocity.X < 0f && num55 < 0f || npc.velocity.Y > 0f && num56 > 0f || npc.velocity.Y < 0f && num56 < 0f)
                        {
                            if (npc.velocity.X < num55)
                            {
                                npc.velocity.X += num53;
                            }
                            else if (npc.velocity.X > num55)
                            {
                                npc.velocity.X -= num53;
                            }
                            if (npc.velocity.Y < num56)
                            {
                                npc.velocity.Y += num53;
                            }
                            else if (npc.velocity.Y > num56)
                            {
                                npc.velocity.Y -= num53;
                            }
                            if ((double)Math.Abs(num56) < (double)num52 * 0.2 && (npc.velocity.X > 0f && num55 < 0f || npc.velocity.X < 0f && num55 > 0f))
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y += num53 * 2f;
                                }
                                else
                                {
                                    npc.velocity.Y -= num53 * 2f;
                                }
                            }
                            if ((double)Math.Abs(num55) < (double)num52 * 0.2 && (npc.velocity.Y > 0f && num56 < 0f || npc.velocity.Y < 0f && num56 > 0f))
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X += num53 * 2f;
                                }
                                else
                                {
                                    npc.velocity.X -= num53 * 2f;
                                }
                            }
                        }
                        else if (num71 > num72)
                        {
                            if (npc.velocity.X < num55)
                            {
                                npc.velocity.X += num53 * 1.1f;
                            }
                            else if (npc.velocity.X > num55)
                            {
                                npc.velocity.X -= num53 * 1.1f;
                            }
                            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num52 * 0.5)
                            {
                                if (npc.velocity.Y > 0f)
                                {
                                    npc.velocity.Y += num53;
                                }
                                else
                                {
                                    npc.velocity.Y -= num53;
                                }
                            }
                        }
                        else
                        {
                            if (npc.velocity.Y < num56)
                            {
                                npc.velocity.Y += num53 * 1.1f;
                            }
                            else if (npc.velocity.Y > num56)
                            {
                                npc.velocity.Y -= num53 * 1.1f;
                            }
                            if ((double)(Math.Abs(npc.velocity.X) + Math.Abs(npc.velocity.Y)) < (double)num52 * 0.5)
                            {
                                if (npc.velocity.X > 0f)
                                {
                                    npc.velocity.X += num53;
                                }
                                else
                                {
                                    npc.velocity.X -= num53;
                                }
                            }
                        }
                    }
                }
                npc.rotation = (float)Math.Atan2(npc.velocity.Y, npc.velocity.X) + 1.57f;


                if (npc.type == 454)
                {
                    float num78 = Vector2.Distance(Main.player[npc.target].Center, npc.Center);
                    int num79 = 0;
                    if (Vector2.Normalize(Main.player[npc.target].Center - npc.Center).ToRotation().AngleTowards(npc.velocity.ToRotation(), (float)Math.PI / 2f) == npc.velocity.ToRotation() && num78 < 350f)
                    {
                        num79 = 4;
                    }
                    if (num79 > npc.frameCounter)
                    {
                        npc.frameCounter += 1.0;
                    }
                    if (num79 < npc.frameCounter)
                    {
                        npc.frameCounter -= 1.0;
                    }
                    if (npc.frameCounter < 0.0)
                    {
                        npc.frameCounter = 0.0;
                    }
                    if (npc.frameCounter > 4.0)
                    {
                        npc.frameCounter = 4.0;
                    }
                }
            }
            if (npc.type < 13 || npc.type > 15 || npc.type != 13 && (npc.type == 13 || Main.npc[(int)npc.ai[1]].alpha >= 85))
            {
                return;
            }
            if (npc.alpha > 0 && npc.life > 0)
            {
                for (int num80 = 0; num80 < 2; num80++)
                {
                    int num81 = Dust.NewDust(new Vector2(npc.position.X, npc.position.Y), npc.width, npc.height, 14, 0f, 0f, 100, default, 2f);
                    Main.dust[num81].noGravity = true;
                    Main.dust[num81].noLight = true;
                }
            }
            if ((npc.position - npc.oldPosition).Length() > 2f)
            {
                npc.alpha -= 42;
                if (npc.alpha < 0)

                {
                    npc.alpha = 0;
                }
            }
        }



        /*


            npc.position += npc.netOffset;
            Vector2 vector3 = npc.Center + (npc.rotation - (float)Math.PI / 2f).ToRotationVector2() * 8f;
            Vector2 vector4 = npc.rotation.ToRotationVector2() * 16f;
            npc.position -= npc.netOffset;
            float num55 = Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2);
            float num56 = Main.player[npc.target].position.Y + (float)(Main.player[npc.target].height / 2);
            int num57 = 1;
            if (num57 > 0)
            {
                num57 *= 16;
                float num62 = num57 - 800;
                if (Main.player[npc.target].position.Y > num62)
                {
                    num56 = num62;
                    if (Math.Abs(npc.Center.X - Main.player[npc.target].Center.X) < 500f)
                    {
                        num55 = ((!(npc.velocity.X > 0f)) ? (Main.player[npc.target].Center.X - 600f) : (Main.player[npc.target].Center.X + 600f));
                    }
                }
            }
            else
            {
                num52 = 14f;
                num53 = 0.5f;
            }
            float num63 = num52 * 1.3f;
            float num64 = num52 * 0.7f;
            float num65 = npc.velocity.Length();
            if (num65 > 0f)
            {
                if (num65 > num63)
                {
                    npc.velocity.Normalize();
                    npc.velocity *= num63;
                }
                else if (num65 < num64)
                {
                    npc.velocity.Normalize();
                    npc.velocity *= num64;
                }
            }
            if (num57 > 0)
            {
                for (int num66 = 0; num66 < 200; num66++)
                {
                    if (Main.npc[num66].active && Main.npc[num66].type == npc.type && num66 != npc.whoAmI)
                    {
                        Vector2 vector6 = Main.npc[num66].Center - npc.Center;
                        if (vector6.Length() < 400f)
                        {
                            vector6.Normalize();
                            vector6 *= 1000f;
                            num55 -= vector6.X;
                            num56 -= vector6.Y;
                        }
                    }
                }
            }
            else
            {
                for (int num67 = 0; num67 < 200; num67++)
                {
                    if (Main.npc[num67].active && Main.npc[num67].type == npc.type && num67 != npc.whoAmI)
                    {
                        Vector2 vector7 = Main.npc[num67].Center - npc.Center;
                        if (vector7.Length() < 60f)
                        {
                            vector7.Normalize();
                            vector7 *= 200f;
                            num55 -= vector7.X;
                            num56 -= vector7.Y;
                        }
                    }
                }
            }
            float num78 = Vector2.Distance(Main.player[npc.target].Center, npc.Center);
            int num79 = 0;
            if (Vector2.Normalize(Main.player[npc.target].Center - npc.Center).ToRotation().AngleTowards(npc.velocity.ToRotation(), (float)Math.PI / 2f) == npc.velocity.ToRotation() && num78 < 350f)
            {
                num79 = 4;
            }
            if ((double)num79 > npc.frameCounter)
            {
                npc.frameCounter += 1.0;
            }
            if ((double)num79 < npc.frameCounter)
            {
                npc.frameCounter -= 1.0;
            }
            if (npc.frameCounter < 0.0)
            {
                npc.frameCounter = 0.0;
            }
            if (npc.frameCounter > 4.0)
            {
                npc.frameCounter = 4.0;
            }
        }*/
    }
}