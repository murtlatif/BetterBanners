using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BetterBanners.Items.Flag.FlagModifier
{
    public class FlagModifier : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flag Modifier");
            Tooltip.SetDefault("This is a modifier for the Flag");
        }

        public override void SetDefaults()
        {
            // Display
            item.width = 28;
            item.height = 14;
            item.maxStack = 99;
            
            // Meta
            item.useTurn = true;
            item.autoReuse = true;
            item.useAnimation = 15;
            item.useTime = 10;
            item.useStyle = 1;
            item.consumable = true;
            item.value = Item.sellPrice(0, 0, 5, 0);
            item.createTile = mod.TileType("FlagModifier");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.Silk, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}