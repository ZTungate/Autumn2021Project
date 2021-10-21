using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Items.ItemSprites;

namespace Sprint2.Items
{
    public abstract class AbstractItem : IItem
    {
        protected AbstractItemSprite sprite;
        protected ItemEnum itemType;
        protected Rectangle rect;
        public AbstractItem(ItemEnum itemType, Rectangle rect)
        {
            this.itemType = itemType;
            this.rect = rect;
        }
        public virtual void CreateSprite()
        {
            this.sprite = ItemSpriteFactory.Instance.GetItemSprite(itemType);
            Rectangle spriteRect = this.sprite.SourceRect[0];
            this.rect.Width = spriteRect.Width * 2;
            this.rect.Height = spriteRect.Height * 2;
        }
        public virtual void Update(GameTime gameTime)
        {
            
            this.sprite.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch batch)
        {
            this.sprite.Draw(batch, this.rect);
        }
    }
}
