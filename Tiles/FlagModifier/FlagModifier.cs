using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using BetterBanners.UI;
using BetterBanners.ModdedPlayer;

namespace BetterBanners.Tiles.FlagModifier
{
    public class FlagModifier : ModTile
    {
		public bool FlagModifierUIOpen = false;
		public Item currentFlag = new Item();

        public override void SetDefaults()
		{
            // Behaviour
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			// Tile Styling
			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
            animationFrameHeight = 38;

			// Map Entry
			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Flag Modifier");
			AddMapEntry(new Color(160, 190, 240), name);
			
			disableSmartCursor = true;
		}

		// Allow smart interactions
		public override bool HasSmartInteract()
		{
			return true;
		}

		// Called to animate the tile
        public override void AnimateTile(ref int frame, ref int frameCounter)
		{
			if (++frameCounter >= 16)
			{
				frameCounter = 0;
				if (++frame >= 4)
				{
					frame = 0;
				}
			}
		}

		// Called when tile is broken
		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("FlagModifier"));
		}

		public override void RightClick(int i, int j)
		{
			bool enableUI = false;
			if (! (FlagModifierUIOpen && FlagModifierUI.visible)) enableUI = true;

			Player player = Main.player[Main.myPlayer];
			BetterBannersPlayer modPlayer = player.GetModPlayer<BetterBannersPlayer>(mod);

			SetUI(enableUI, modPlayer, i, j);
		}

		public void SetUI(bool enable, BetterBannersPlayer modPlayer, int i, int j)
		{
			int playSound;
			if (enable) {
				playSound = SoundID.MenuOpen;
				modPlayer.OpenFlagModifier(new Point16(i, j), this);
			} else {
				playSound = SoundID.MenuClose;
				modPlayer.CloseFlagModifier();
			}

			Main.PlaySound(playSound);
			this.FlagModifierUIOpen = enable;

		}

		public override void MouseOver(int i, int j)
		{
			Player player = Main.LocalPlayer;
			player.noThrow = 2;
			player.showItemIcon = true;
			player.showItemIcon2 = mod.ItemType("FlagModifier");
		}
    }
}