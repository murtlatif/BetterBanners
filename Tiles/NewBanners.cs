using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using BetterBanners.ID;

namespace BetterBanners.Tiles
{
    public class NewBanners : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;

            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
			TileObjectData.newTile.CoordinateHeights = new int[]{ 16, 16, 16 };
			TileObjectData.newTile.StyleHorizontal = true;
			TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);

            dustType = -1;
            disableSmartCursor = true;
            ModTranslation name = CreateMapEntryName();
            name.SetDefault("Banner");
            AddMapEntry(new Color(13, 88, 130), name);
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int style = frameX / 18;
            
            if (style < BannerID.Banners.Length && style >= 0)
            {
                string item = BannerID.getBannerFromID(style).BannerName;
                Item.NewItem(i * 16, j * 16, 16, 48, mod.ItemType(item));
            }
        }

        public override void NearbyEffects(int i, int j, bool closer)
        {
            if (closer)
            {
                Player player = Main.LocalPlayer;
                int style = Main.tile[i, j].frameX / 18;
                if (style < BannerID.Banners.Length && style >= 0)
                {
                    int[] npcBuffs = BannerID.getBannerFromID(style).NPCs;
                    if (npcBuffs != null) {
                        if (npcBuffs.Length > 0)    
                        {
                            foreach (int npcBuff in npcBuffs)
                            {
                                player.NPCBannerBuff[Terraria.Item.NPCtoBanner(npcBuff)] = true;
                            }
                        }
                    }
                    player.hasBanner = true;
                }
            }
        }

        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
		{
			if (i % 2 == 1)
			{
				spriteEffects = SpriteEffects.FlipHorizontally;
			}
		}
    }
}