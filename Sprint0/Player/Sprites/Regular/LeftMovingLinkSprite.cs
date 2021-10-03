using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class LeftMovingLinkSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 128f; 
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 2;
        public float SpriteSpeed { get; set; } = 1;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public int scale = 2;

        Link player;
        public LeftMovingLinkSprite(Texture2D spriteSheet, Link player)
        {
            this.player = player;

            Texture = spriteSheet;  //Set the texture2D to the provided spriteSheet (already initialized by factory)
            SourceRect = new Rectangle[2];
            
            SourceRect[0] = new Rectangle(52, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(35, 11, 16, 16);
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public void Update(GameTime gameTime)
        {
            // Implement animation changes here

            player.position.X -= SpriteSpeed;

            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (Timer > Interval)
            {
                CurrentFrame++;


                if (CurrentFrame > FrameCount - 1) {
                    CurrentFrame = 0;
                }

                Timer = 0;
            }
            else
            {
                //Increment timer by the elapsed time in game.
                Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame%FrameCount].Width*scale, SourceRect[CurrentFrame%FrameCount].Height*scale);
            /*spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);*/
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 1);

        }

    }
}
