using Terraria;
using Terraria.ModLoader;

namespace BetterBanners.Items.Flag
{
    [AutoloadEquip(EquipType.Balloon)]
    public class Flag : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flag");
            Tooltip.SetDefault("\"Onwards! We must fight!\"");
        }

        public override void SetDefaults()
        {
            // Display
            item.width = 32;
            item.height = 32;
            item.holdStyle = 1;

            // Meta
            item.maxStack = 1;
            item.accessory = true;

            // Stats
            item.rare = 3;
            item.defense = 1;
        }
    }
}