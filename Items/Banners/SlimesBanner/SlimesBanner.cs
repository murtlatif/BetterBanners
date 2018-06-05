using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using BetterBanners.ID;

namespace BetterBanners.Items.Banners.SlimesBanner
{
	public class SlimesBanner : ModItem
	{
		
		// This tooltip is assigned from .lang files.
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Slimes Banner");
			//Tooltip.SetDefault("Provides a bonus against all surface slimes.");
		}

		public override void SetDefaults()
		{
			item.width = 10;
			item.height = 24;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.rare = 1;
			item.value = Item.buyPrice(0, 0, 10, 0);
			item.createTile = mod.TileType("NewBanners");
			item.placeStyle = BannerID.getIDFromBanner(BannerID.getBannerFromName((this.GetType().Name))); 
			// placeStyle is which frame of the {createTile} tile should be placed starting from 0
		}

		public override void AddRecipes()
		{
			int[] ingredients = {
				ItemID.GreenSlimeBanner,
				ItemID.SlimeBanner,
				ItemID.UmbrellaSlimeBanner,
				ItemID.PurpleSlimeBanner,
				ItemID.IceSlimeBanner,
				ItemID.JungleSlimeBanner,
				ItemID.SandSlimeBanner,
			};

			ModRecipe recipe = new ModRecipe(mod);
			
			foreach (int ingredient in ingredients)
			{
				recipe.AddIngredient(ingredient);
			}

			recipe.SetResult(this);
			recipe.AddRecipe();

		}
	}
}
