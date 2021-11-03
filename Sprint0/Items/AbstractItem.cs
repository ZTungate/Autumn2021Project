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
        protected AbstractSprite sprite;
        protected ItemEnum itemType;
        protected Rectangle rect;

        Rectangle IItem.rect { get => this.rect; set => this.rect = value; }

        public AbstractItem(ItemEnum itemType, Rectangle rect)
        {
            this.itemType = itemType;
            this.rect = rect;
        }
        public virtual void CreateSprite(float scaleX, float scaleY)
        {
            this.sprite = ItemSpriteFactory.Instance.GetItemSprite(itemType);
            this.rect.Width = (int)(sprite.SourceRect[0].Width * scaleX);
            this.rect.Height = (int)(sprite.SourceRect[0].Height * scaleY);
        }
        public virtual void Update(GameTime gameTime)
        {
            
            this.sprite.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch batch)
        {
            this.sprite.Draw(batch, this.rect);
        }
        public virtual void SetRectangle(Rectangle rect)
        {
            this.rect = rect;
        }
        public virtual Rectangle GetRectangle()
        {
            return this.rect;
        }
        public AbstractSprite GetSprite()
        {
            return this.sprite;
        }
        public Point GetPosition()
        {
            return this.rect.Location;
        }
        public void SetPosition(Point pos)
        {
            this.rect = new Rectangle(pos, rect.Size);
        }
    }
}
