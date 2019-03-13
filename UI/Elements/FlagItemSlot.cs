using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterBanners.UI.Elements
{
    public class FlagItemSlot : UIItemSlot
    {
        public FlagItemSlot(Item itemInSlot) : base(itemInSlot)
        {
        }

        public override bool AcceptItems(Item item)
        {
            if (item.stack > 1) return false;
            return item.type == BetterBanners.instance.ItemType("Flag");
        }
    }
}