using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class BombSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 100f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 4;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public int counter = 0;
        public BombSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[4];

            //Set the two frames for the bat animation
            SourceRect[0] = new Rectangle(129, 185, 8, 16);
            SourceRect[1] = new Rectangle(138, 185, 16, 16);
            SourceRect[2] = new Rectangle(155, 185, 16, 16);
            SourceRect[3] = new Rectangle(172, 185, 16, 16);
        }

        public void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (Timer > Interval)
            {
                counter++;

                if (counter > 7) {
                    CurrentFrame++;
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
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width * (int)LinkConstants.scaleX, SourceRect[CurrentFrame].Height * (int)LinkConstants.scaleY);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }
    }
}
