using System;
using System.Collections.Generic;
using System.Text;
using Sprint2;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint2
{
    public abstract class AbstractSprite : ISprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 80f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 1;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }

        public AbstractSprite(Texture2D spriteSheet, Rectangle[] sourceRect)
        {
            this.Texture = spriteSheet;
            this.SourceRect = sourceRect;
            this.FrameCount = sourceRect.Length;
        }
        public void FrameStep(GameTime gameTime)
        {
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
        public virtual void Update(GameTime gameTime)
        {
            //no-op
        }
        public void Draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            spriteBatch.Draw(Texture, rect, SourceRect[CurrentFrame], Color.White);
        }
    }
}
