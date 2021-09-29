using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    class AnimatedStillSprite : IAnimatedSprite
    {

        public float Timer { get; set; } = 0f;

        public float Interval { get; set; } = 40f;
        public int CurrentFrame { get; set; } = 0;

        public int FrameCount { get; private set; } = 34;

        public float SpriteSpeed { get; set; } = 0;

        public Texture2D Texture { get; set; }

        public Rectangle[] SourceRect { get; set; }

        public Vector2 Position { get; set; }
        public AnimatedStillSprite(Game1 myGame)
        {
            Texture = myGame.Content.Load<Texture2D>("waterBall");


            SourceRect = new Rectangle[34];

            for (int i = 0; i < FrameCount; i++) { //create an array of the different sprites from the sprite sheet
                SourceRect[i] = new Rectangle(0, i * Texture.Height / FrameCount, Texture.Width, Texture.Height / FrameCount);
            }

            Position = new Vector2(myGame._graphics.PreferredBackBufferWidth / 2 - SourceRect[0].Width / 2, myGame._graphics.PreferredBackBufferHeight / 2 - SourceRect[0].Height / 2);

        }

        public void Update(GameTime gameTime)
        {//animate the sprites
            if (Timer > Interval) {
                CurrentFrame++;

                if (CurrentFrame > FrameCount - 1) {
                    CurrentFrame = 0;
                }
                Timer = 0;
            }
            else {
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

    }
}
