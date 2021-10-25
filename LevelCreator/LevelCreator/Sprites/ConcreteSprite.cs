using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelCreator.Sprites
{
    public class ConcreteSprite : ISprite
    {
        protected Rectangle destRect;
        protected Texture2D texture;
        protected Rectangle sourceRect;
        protected Color color;

        public ConcreteSprite(Texture2D texture, Rectangle source, Color color)
        {
            sourceRect = source;
            this.texture = texture;
            this.color = color;
        }
        public void Update(GameTime gameTime)
        {
            //no-op
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle destRect)
        {
            this.destRect = destRect;
            spriteBatch.Draw(texture, this.destRect, sourceRect, color);
        }
        public Rectangle GetDestinationRect()
        {
            return this.destRect;
        }
    }
}
