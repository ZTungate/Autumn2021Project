using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Enemies;

namespace Sprint2
{
    public class SlimeSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 40f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 2;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public SlimeSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[2];

            //Set the two frames for the slime animation
            SourceRect[0] = new Rectangle(1, 11, 8, 16);
            SourceRect[1] = new Rectangle(10, 11, 8, 16);

            //Dummy position, needs to be fixed by adding pos relevant to the enemy.
            Position = new Vector2(500, 100);
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
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, (int)(SourceRect[CurrentFrame].Width * EnemyConstants.scaleX), (int)(SourceRect[CurrentFrame].Height * EnemyConstants.scaleY));
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }

    }
}
