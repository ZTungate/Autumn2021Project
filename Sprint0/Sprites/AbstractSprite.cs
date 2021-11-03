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
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }

        public SpriteEffects effects = SpriteEffects.None;

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
        public virtual void Draw(SpriteBatch spriteBatch, Rectangle rect)
        {
            //LayerDepth set to 1, normally this would mean this object will always been drawn in front but because of Begin() call in Game1 objects are drawn in the order their Draw() method is called
            spriteBatch.Draw(Texture, rect, SourceRect[CurrentFrame], Color.White, 0, Vector2.Zero, effects, 1);
        }
    }
}
