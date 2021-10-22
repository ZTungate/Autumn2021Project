using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    public class FireSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 100f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 2;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public int scale = 2;
        public FireSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[1];

            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(191, 185, 16, 16);

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
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[0].Width * 2, SourceRect[0].Height * 2);
            switch (CurrentFrame) {
                case 0:
                    spriteBatch.Draw(Texture, Position, SourceRect[0], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);
                    break;
                case 1:
                    spriteBatch.Draw(Texture, Position, SourceRect[0], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 1);
                    break;

            }
        }

    }
}
