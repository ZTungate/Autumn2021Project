using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    public class BoomerangSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 20f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 8;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public BoomerangSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[8];

            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(290, 15, 8, 8);
            SourceRect[1] = new Rectangle(299, 15, 8, 8);
            SourceRect[2] = new Rectangle(308, 15, 8, 8);
            SourceRect[3] = new Rectangle(317, 15, 8, 8);
            SourceRect[4] = new Rectangle(326, 15, 8, 8);
            SourceRect[5] = new Rectangle(335, 15, 8, 8);
            SourceRect[6] = new Rectangle(344, 15, 8, 8);
            SourceRect[7] = new Rectangle(353, 15, 8, 8);
        }

        public void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (Timer > Interval)
            {
                CurrentFrame++;

                if (CurrentFrame > FrameCount - 1)
                {
                    CurrentFrame = 0;
                }
                Timer = 0;
            }
            else
            {
                //Increment timer based on the elapsed time from the last check.
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw projectile at its position at twice its source size.
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width * 2, SourceRect[CurrentFrame].Height * 2);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }

    }
}
