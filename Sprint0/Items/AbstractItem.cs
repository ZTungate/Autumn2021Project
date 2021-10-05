using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Items
{
    public abstract class AbstractItem : IItem
    {
        protected ISprite sprite;
        protected ItemEnum itemType;
        protected Vector2 position;
        public AbstractItem(ItemEnum itemType, Vector2 pos)
        {
            this.itemType = itemType;
            this.position = pos;
        }
        public virtual void CreateSprite()
        {
            this.sprite = ItemSpriteFactory.Instance.GetItemSprite(itemType);
        }
        public virtual void Update(GameTime gameTime)
        {
            //Update position of sprite to item position
            //NOTE: THIS SHOULD BE DONE IN THE DRAW CALL, IT IS BAD PRACTICE TO HAVE DUPLICATE POSITION VARIABLES IN ITEM AND SPRITE
            this.sprite.Position = position;
            this.sprite.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch batch)
        {
            this.sprite.Draw(batch);
        }
    }
}
