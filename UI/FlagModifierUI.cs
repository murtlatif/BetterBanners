using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI;

namespace BetterBanners.UI
{
    class FlagModifierUI : UIState
    {
        public UIPanel FlagModifierPanel;
        public static bool visible = false;

        public override void OnInitialize()
        {
            Main.NewText("Initializing...");
            FlagModifierPanel = new UIPanel();
            FlagModifierPanel.SetPadding(0);
            FlagModifierPanel.Left.Set(700f, 0f);
            FlagModifierPanel.Top.Set(200f, 0f);
            FlagModifierPanel.Width.Set(500f, 0f);
            FlagModifierPanel.Height.Set(100f, 0f);
            FlagModifierPanel.BackgroundColor = new Color(72, 110, 169, 100);

            Texture2D buttonDeleteTexture = ModLoader.GetTexture("Terraria/UI/ButtonDelete");
			UIImageButton closeButton = new UIImageButton(buttonDeleteTexture);
			closeButton.Left.Set(-32, 1f);
			closeButton.Top.Set(10, 0f);
			closeButton.Width.Set(22, 0f);
			closeButton.Height.Set(22, 0f);
			closeButton.OnClick += new MouseEvent(CloseButtonClicked);
			FlagModifierPanel.Append(closeButton);

            base.Append(FlagModifierPanel);
        }

        private void CloseButtonClicked(UIMouseEvent evt, UIElement listeningElement)
		{
			Main.PlaySound(SoundID.MenuOpen);
			visible = false;
		}
    }
}