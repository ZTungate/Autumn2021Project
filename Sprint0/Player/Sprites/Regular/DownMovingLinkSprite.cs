using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Player;

namespace Sprint2.Player
{
    public class DownMovingLinkSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 128f; 
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 2;
        public float SpriteSpeed { get; set; } = 1;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public Color[] colors;
        int numColors = 2;

        ILink player;
        public DownMovingLinkSprite(Texture2D spriteSheet, ILink player)
        {
            this.player = player;

            colors = new Color[numColors];
            colors[0] = Color.White;
            colors[1] = Color.Red;

            Texture = spriteSheet;  //Set the texture2D to the provided spriteSheet (already initialized by factory)
            SourceRect = new Rectangle[2];
            
            SourceRect[0] = new Rectangle(18, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(1, 11, 16, 16);
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public void Update(GameTime gameTime)
        {

            /*   if (player.isDamaged) //damage color flash
               {
                   if (Timer > colorFlashInterval)
                   {
                       colorIndex++;
                       Timer = 0;
                   }
                   else
                   {
                       Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                   }
               }
               else
               {
                   colorIndex = 0;
               }*/
            // Implement animation changes here

            player.Move(new Vector2(0, SpriteSpeed));

            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (Timer > Interval)
            {
                CurrentFrame++;


                if (CurrentFrame > FrameCount - 1) { //reset the current frame to zero so there are no index errors
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
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame%FrameCount].Width* (int)LinkConstants.scaleX, SourceRect[CurrentFrame%FrameCount].Height* (int)LinkConstants.scaleY);
            /*spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);*/
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.None, 1);

        }

    }
}
