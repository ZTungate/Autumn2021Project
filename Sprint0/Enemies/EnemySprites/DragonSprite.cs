using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class DragonSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 80f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 4;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public DragonSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[4];

            //Set the two frames for the slime animation
            SourceRect[0] = new Rectangle(1, 11, 24, 32);
            SourceRect[1] = new Rectangle(26, 11, 24, 32);
            SourceRect[2] = new Rectangle(51, 11, 24, 32);
            SourceRect[3] = new Rectangle(76, 11, 24, 32);

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
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width, SourceRect[CurrentFrame].Height);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }

    }
}
