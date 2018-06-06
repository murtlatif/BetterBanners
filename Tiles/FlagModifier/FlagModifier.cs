using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using BetterBanners.UI;

namespace BetterBanners.Tiles.FlagModifier
{
    public class FlagModifier : ModTile
    {
        public override void SetDefaults()
		{
            // Behaviour
			Main.tileSolidTop[Type] = false;
			Main.tileFrameImportant[Type] = true;
			Main.tileNoAttach[Type] = true;
			Main.tileTable[Type] = false;
			Main.tileLavaDeath[Type] = true;
			TileID.Sets.HasOutlines[Type] = true;

			TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
			TileObjectData.addTile(Type);
            animationFrameHeight = 38;

			ModTranslation name = CreateMapEntryName();
			name.SetDefault("Flag Modifier");
			AddMapEntry(new Color(200, 200, 200), name);
			disableSmartCursor = false;
		}

		public override bool HasSmartInteract()
		{
			return true;
		}

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

		public override void KillMultiTile(int i, int j, int frameX, int frameY)
		{
			Item.NewItem(i * 16, j * 16, 32, 16, mod.ItemType("FlagModifier"));
		}

		public override void RightClick(int i, int j)
		{
			FlagModifierUI.visible = !FlagModifierUI.visible;
		}
    }
}