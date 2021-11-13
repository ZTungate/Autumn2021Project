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

        public Color Color { get; set; } = Color.White;


        public void Update(GameTime gameTime) { }
        public void Draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            
        }
    }


}
