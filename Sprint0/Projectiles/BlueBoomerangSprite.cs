using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3
{
    public class BlueBoomerangSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 20f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 3;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public int scale = 2;

        public int TotalFrames = 0;

        public bool incFrame = true;

        public BlueBoomerangSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[3];

            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(91, 185, 8, 16);
            SourceRect[1] = new Rectangle(100, 185, 8, 16);
            SourceRect[2] = new Rectangle(109, 185, 8, 16);

        }

        public void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (Timer > Interval) {
                TotalFrames++;
                if (incFrame) {

                    CurrentFrame++;

                    if (CurrentFrame > FrameCount - 1) {
                        incFrame = false;
                        CurrentFrame = 1;

                    }
                    Timer = 0;
                }
                else {
                    CurrentFrame--;

                    if (CurrentFrame < 0) {
                        incFrame = true;
                        CurrentFrame = 1;

                    }
                    Timer = 0;
                }
            }
            else {
                //Increment timer based on the elapsed time from the last check.
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw projectile at its position at twice its source size.

            int cycle = TotalFrames % 8;

            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width * 2, SourceRect[CurrentFrame].Height * 2);
            switch (cycle) {
                case 0:
                case 1:
                case 2:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);
                    break;
                case 3:
                case 4:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 1);
                    break;
                case 5:
                case 6:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);

                    break;
                case 7:
                    spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.FlipVertically, 1);
                    break;

            }
        }
    }

}
