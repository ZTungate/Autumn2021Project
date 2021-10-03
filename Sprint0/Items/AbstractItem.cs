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
        public AbstractItem(ISprite sprite, Vector2 pos)
        {
            this.sprite = sprite;
            this.position = pos;
        }
        public virtual void Update(GameTime gameTime)
        {
            this.sprite.Position = position;
            this.sprite.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch batch)
        {
            this.sprite.Draw(batch);
        }
    }
}
