using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace LevelCreator.Sprites
{
    public class TextSprite : ISprite
    {
        private string text;
        private Color color;
        private SpriteFont font;
        public TextSprite(SpriteFont font, String text, Color color)
        {
            this.font = font;
            this.text = text;
            this.color = color;
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle destRect, float order)
        {
            spriteBatch.DrawString(font, text, new Vector2(destRect.X, destRect.Y), color, 0, Vector2.Zero, 1, SpriteEffects.None, 1.0f);
        }

        public void Update(GameTime gameTime)
        {
            //no-op
        }

        public string GetText()
        {
            return this.text;
        }
        public void SetText(string text)
        {
            this.text = text;
        }
    }
}
