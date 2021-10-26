using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class UpBlueArrowSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 800f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 3;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public int scale = 2;

        public int TotalFrames = 0;

        public bool incFrame = true;

        public UpBlueArrowSprite(Texture2D spriteSheet)
        {
            //Set the texture2D to the provided spriteSheet (already initialized by factory)
            Texture = spriteSheet;
            SourceRect = new Rectangle[2];

            SourceRect[0] = new Rectangle(27, 185, 8, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(53, 185, 8, 16);

        }

        public void Update(GameTime gameTime)
        {
            // Implement animation changes here

            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (Timer > Interval) {

                CurrentFrame = 1;
            }
            else {
                //Increment timer by the elapsed time in game.
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame % FrameCount].Width * (int)LinkConstants.scaleX, SourceRect[CurrentFrame % FrameCount].Height * (int)LinkConstants.scaleY);
            /*spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);*/
            spriteBatch.Draw(Texture, Position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.None, 1);

        }
    }

}
