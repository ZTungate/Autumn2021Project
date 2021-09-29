using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class NonAnimatedStillSprite : ISprite
    {


        public int CurrentFrame { get; set; } = 0;

        public int FrameCount { get; private set; } = 1;

        public float SpriteSpeed { get; set; } = 0;

        public Texture2D Texture { get; set; }

        public Rectangle[] SourceRect { get; set; }

        public Vector2 Position { get; set; }


        public NonAnimatedStillSprite(Game1 myGame)
        {
            Texture = myGame.Content.Load<Texture2D>("ball");

            SourceRect = new Rectangle[1];

            SourceRect[0] = new Rectangle(0, CurrentFrame * Texture.Height / FrameCount, Texture.Width, Texture.Height/FrameCount);

            Position = new Vector2(myGame._graphics.PreferredBackBufferWidth / 2 - SourceRect[0].Width / 2, myGame._graphics.PreferredBackBufferHeight / 2 - SourceRect[0].Height / 2);
        }

        public void Update(GameTime gameTime)
        {

        }

    }
}
