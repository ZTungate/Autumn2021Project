using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class TextSprite : ISprite
    {
        public int CurrentFrame { get; set; }

        public int FrameCount { get; private set; }

        public float SpriteSpeed { get; set; } = 0;

        public Texture2D Texture { get; set; }

        public Rectangle[] SourceRect { get; set; }

        public Vector2 Position { get; set; }

        public void Update(GameTime gameTime) { }
    }


}
