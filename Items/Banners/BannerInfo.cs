namespace BetterBanners.Items.Banners
{
    public class BannerInfo
    {
        private string bannerName;
        public string BannerName { get; set; }

        private int[] npcs;
        public int[] NPCs { get; set; }
        
        public BannerInfo(string name, int[] npcList)
        {
            NPCs = npcList;
            BannerName = name;
        }
    }
}