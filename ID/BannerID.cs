using Terraria.ID;
using BetterBanners.Items.Banners;

namespace BetterBanners.ID
{
    public class BannerID
    {
        private static BannerInfo[] banners = {
            new BannerInfo(
                "SlimesBanner",
                new int[] {
                    NPCID.GreenSlime,
                    NPCID.BlueSlime,
                    NPCID.PurpleSlime,
                    NPCID.IceSlime,
                    NPCID.SandSlime,
                    NPCID.JungleSlime,
                    NPCID.UmbrellaSlime,
                }
            ),
            new BannerInfo(
                "PreHardmodeNightBanner",
                new int[] {
                    NPCID.Zombie,
                    NPCID.DemonEye,
                }
            ),
        };

        public static BannerInfo[] Banners { 
            get { return banners; }
        }

        public static BannerInfo getBannerFromName(string name)
        {
            for (int i = 0; i < Banners.Length; i++)
            {
                if (Banners[i].BannerName == name)
                {
                    return Banners[i];
                }
            }
            return null;
        }
        public static BannerInfo getBannerFromID(int id)
        {
            return Banners[id];
        }

        public static int getIDFromBanner(BannerInfo targetBanner)
        {
            for (int i = 0; i < Banners.Length; i++)
            {
                if (Banners[i] == targetBanner)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}