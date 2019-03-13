using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using BetterBanners.Tiles.FlagModifier;
using BetterBanners.UI;
using System;

namespace BetterBanners.ModdedPlayer
{
    public class BetterBannersPlayer : ModPlayer
    {
        private Point16 whereFlagModifierOpened = new Point16(-1, -1);
        public Point16 WhereFlagModifierOpened { get; set; }
        public FlagModifier openedFlagModifier;

        // Called when player is dead
        public override void UpdateDead()
        {
            if (player.whoAmI == Main.myPlayer)
            {
                CloseFlagModifier();
            }
        }


        public override void ResetEffects()
        {
            if (player.whoAmI != Main.myPlayer) return;

            if (WhereFlagModifierOpened.X >= 0 && WhereFlagModifierOpened.Y >= 0 && 
            (player.chest != -1 || player.sign != -1 || player.talkNPC != -1))
            {
                CloseFlagModifier();
                Main.NewText("ResetEffects: Closed flag modifier in case 1 {Player began an interaction!}");
            }

            else if (WhereFlagModifierOpened.X >= 0 && WhereFlagModifierOpened.Y >= 0)
            {
                int playerX = (int)(player.Center.X / 16f);
                int playerY = (int)(player.Center.Y / 16f);
                if ((Math.Abs(playerX - WhereFlagModifierOpened.X) > Player.tileRangeX) ||
                    (Math.Abs(playerY - WhereFlagModifierOpened.Y) > Player.tileRangeY))
                {
                    Main.PlaySound(SoundID.MenuClose);
                    Main.NewText("ResetEffects: Closed flag modifier in case 2 {Player out of range}");
                    CloseFlagModifier();

                }

                else if (!(TileLoader.GetTile(Main.tile[WhereFlagModifierOpened.X, WhereFlagModifierOpened.Y].type) is FlagModifier))
                {
                    Main.PlaySound(SoundID.MenuClose);
                    CloseFlagModifier();
                    Main.NewText("ResetEffects: Closed flag modifier in case 3 {Tile is not FlagModifier}");
                }
            }
        }

        public void CloseFlagModifier()
        {
            WhereFlagModifierOpened = new Point16(-1, -1);
            openedFlagModifier = null;
            FlagModifierUI.CloseUI();
            Main.NewText("Closed Flag Modifier");
        }

        public void OpenFlagModifier(Point16 where, FlagModifier flagModifier)
        {
            if (player.talkNPC != -1 || player.sign != -1 || player.chest != -1)
            {
                player.talkNPC = player.sign = player.chest = -1;
            }
            WhereFlagModifierOpened = where;
            openedFlagModifier = flagModifier;
            FlagModifierUI.OpenUI(openedFlagModifier.currentFlag);
            Main.NewText("Opened flag modifier at " + where.X + ", " + where.Y);
        }
    }
}