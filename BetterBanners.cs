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
		public static BetterBanners instance;

		public BetterBanners()
		{
			/*	TODO:
			*	MODIFY: {FlagItemSlot.cs / UIItemSlot.cs} -> Complete UI interface and allow the insertion/removal of a flag item
			* 	CREATE: {BrannerItemSlot.cs} -> Allow the insertion/removal of a banner into a flag
			* 	MODIFY: {Flag.cs} to be upgradeable and unlock up to 5 banner slots
			*	MODIFY: {FlagModifier.cs} to close the UI after moving the distance (done, but not implemented. connect modPlayer.OpenFlagModifier())
			*/
		}

		public override void Load()
		{
			instance = this;

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

		public override void Unload()
		{
			instance = null;
		}
	}
}
