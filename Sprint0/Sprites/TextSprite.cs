using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    class TextSprite : ISprite
    {
        public int CurrentFrame { get; set; }

        public int FrameCount { get; private set; }

        public float SpriteSpeed { get; set; } = 0;

        public Texture2D Texture { get; set; }

        public Rectangle[] SourceRect { get; set; }
        public bool IsUISprite { get; set; } = true;

        public Color Color { get; set; } = Color.White;

        private string text;
        private Color color;
        private SpriteFont font;
        private Point position;
        public TextSprite(SpriteFont font, String text, Color color, Point pos)
        {
            this.font = font;
            this.text = text;
            this.color = color;
            this.position = pos;
        }
        public void Update(GameTime gameTime) { }
        public void Draw(SpriteBatch spriteBatch, Rectangle destRect)
        {
            spriteBatch.DrawString(font, text, destRect.Location.ToVector2(), color, 0, Vector2.Zero, 1, SpriteEffects.None, 1.0f);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position.ToVector2(), color, 0, Vector2.Zero, 1, SpriteEffects.None, 1.0f);
        }
        public void SetPosition(Point pos)
        {
            this.position = pos;
        }
        public Point GetPosition()
        {
            return this.position;
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
