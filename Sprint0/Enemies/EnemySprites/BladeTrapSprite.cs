using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class BladeTrapSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 80f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 1;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public BladeTrapSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[1];

            //Set the source rectangle
            SourceRect[0] = new Rectangle(164, 59, EnemyConstants.stdEnemySize.Width, EnemyConstants.stdEnemySize.Height);
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
            //Draw enemy at its position at twice its source size.
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width * 2, SourceRect[CurrentFrame].Height * 2);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }
    }
}
