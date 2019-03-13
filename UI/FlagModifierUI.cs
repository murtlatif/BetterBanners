using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;
using BetterBanners.UI.Elements;

namespace BetterBanners.UI
{
    class FlagModifierUI : UIState
    {
        public UIPanel FlagModifierPanel;
        public static bool visible = false;
        public static Item currentFlag = new Item();

        public static void OpenUI(Item flag)
        {
            currentFlag = flag;
            visible = true;
        }

        public static void CloseUI()
        {
			visible = false;
        }

        public override void OnInitialize()
        {
            // UI Panel
            FlagModifierPanel = new UIPanel();
            FlagModifierPanel.SetPadding(0);
            FlagModifierPanel.Left.Set(700f, 0f);
            FlagModifierPanel.Top.Set(200f, 0f);
            FlagModifierPanel.Width.Set(500f, 0f);
            FlagModifierPanel.Height.Set(100f, 0f);

            // Close UI button
            Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(-32, 1f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			FlagModifierPanel.Append(closeButton);

            // Title text
            UIText title = new UIText("Flag Modifier", 1, false);
            title.Left.Set(10, 0f);
            title.Top.Set(10, 0f);
            FlagModifierPanel.Append(title);

            // Flag item slot
            FlagItemSlot itemSlot = new FlagItemSlot(currentFlag);
            itemSlot.Top.Set(-74, 1f);
            itemSlot.Left.Set(10, 0f);
            FlagModifierPanel.Append(itemSlot);

            base.Append(FlagModifierPanel);
        }

        // Called when the close UI button is clicked
        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
		{
			CloseUI();
		}

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            // Do not allow usage of items when clicking interface
            if (FlagModifierPanel.ContainsPoint(Main.MouseScreen)) 
            {
                Main.LocalPlayer.mouseInterface = true;
            }
        }
    }
}