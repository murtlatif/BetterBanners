using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace BetterBanners.UI.Elements
{
    public class UIItemSlot : UIElement
    {
        internal float scale = 1f;
        private bool disabled;
        protected Item currentItem = new Item();
        Item CurrentItem { get; set; }

        public UIItemSlot(Item itemInSlot, int width = 64, int height = 64, bool disabled = false)
        {
            currentItem = itemInSlot;
            Width.Set(width, 0f);
            Height.Set(height, 0f);
            this.disabled = disabled;
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle innerDimensions = base.GetInnerDimensions();
            
            Vector2 drawPosition = new Vector2(innerDimensions.X + 10, innerDimensions.Y + 10);
            Texture2D slotTexture = disabled ? Main.inventoryBack5Texture : Main.inventoryBack9Texture;
            Color slotColor = new Color(73, 94, 171);

            // Draw in the item slot
            spriteBatch.Draw(slotTexture, drawPosition, null, new Color(), 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);

            // Draw in texture of item
            if (CurrentItem != null)
            {
                Texture2D itemTexture = Main.itemTexture[CurrentItem.type];
                Rectangle innerRectangle = innerDimensions.ToRectangle();
                Main.NewText("Slotted item! : " + CurrentItem.Name);
                //spriteBatch.Draw(itemTexture, drawPosition, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            }
        }

        public virtual bool AcceptItems(Item item)
        {
            return !disabled;
        }

        public virtual void SwapItem()
        {
            Item item = Main.mouseItem.Clone();
            if (true)
            {
                Main.mouseItem = this.currentItem.Clone();
                if (Main.mouseItem.type > 0)
                {
                    Main.playerInventory = true;
                }
                this.currentItem = item.Clone();
            }
        }

        public override void Click(UIMouseEvent evt)
        {
            SwapItem();
        }
    }
}