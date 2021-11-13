using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Items.ItemSprites;

namespace Poggus.Items
{
    public abstract class AbstractItem : IItem
    {
        protected ISprite sprite;
        protected ItemEnum itemType;
        protected Rectangle rect;

        Rectangle IItem.rect { get => this.rect; set => this.rect = value; }

        public AbstractItem(ItemEnum itemType, Point pos, Point size)
        {
            this.itemType = itemType;
            this.rect = new Rectangle(pos, size);
        }
        public virtual void CreateSprite()
        {
            this.sprite = ItemSpriteFactory.Instance.GetItemSprite(itemType);
            this.rect.Width = (int)(sprite.SourceRect[0].Width * Game1.gameScaleX);
            this.rect.Height = (int)(sprite.SourceRect[0].Height * Game1.gameScaleY);
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
