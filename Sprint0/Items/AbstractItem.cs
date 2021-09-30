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
        public AbstractItem(ISprite sprite)
        {
            this.sprite = sprite;
        }
        public virtual void Update(GameTime gameTime)
        {
            this.sprite.Update(gameTime);
        }
        public virtual void Draw(SpriteBatch batch)
        {
            this.sprite.Draw(batch);
        }
    }
}
