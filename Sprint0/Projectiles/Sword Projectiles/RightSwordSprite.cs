using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class RightSwordSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 50f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 4;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public int scale = 2;

        public int TotalFrames = 0;

        public bool incFrame = true;

        public RightSwordSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[FrameCount];

            SourceRect[0] = new Rectangle(10, 154, 16, 16);  //Set the frame for sword
            SourceRect[1] = new Rectangle(45, 154, 16, 16);  //Set the frame for sword
            SourceRect[2] = new Rectangle(80, 154, 16, 16);  //Set the frame for sword
            SourceRect[3] = new Rectangle(115, 154, 16, 16);  //Set the frame for sword

        }

        public void Update(GameTime gameTime)
        {

            if (Timer > Interval) { //animate the sprites
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
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame % FrameCount].Width * scale, SourceRect[CurrentFrame % FrameCount].Height * scale);
            /*spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);*/
            spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);

        }
    }

}
