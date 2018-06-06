using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.GameContent.UI;
using Terraria.UI;

using BetterBanners.UI;

using System;
using System.IO;
using System.Collections.Generic;

namespace BetterBanners
{
	class BetterBanners : Mod
	{
		internal FlagModifierUI flagModifierUI;
		private UserInterface userInterface;

		public BetterBanners()
		{
		}

		public override void Load()
		{
			flagModifierUI = new FlagModifierUI();
			flagModifierUI.Activate();
			userInterface = new UserInterface();
			userInterface.SetState(flagModifierUI);
		}

		public override void UpdateUI(GameTime gameTime)
		{
			if (userInterface != null && FlagModifierUI.visible)
				userInterface.Update(gameTime);
		}

		public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
		{
			int MouseTextIndex = layers.FindIndex(layer => layer.Name.Equals("Vanilla: Mouse Text"));
			if (MouseTextIndex != -1)
			{
				layers.Insert(MouseTextIndex, new LegacyGameInterfaceLayer(
					"BetterBanners: Flag Modifier",
					delegate
					{
						if (FlagModifierUI.visible)
						{
							flagModifierUI.Draw(Main.spriteBatch);
						}
						return true;
					},
					InterfaceScaleType.UI)
				);
			}
		}
	}
}
