using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class DownMovingLinkSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public Color[] colors;
        int numColors = 2;

        public int scale = 2;

        ILink player;
        public DownMovingLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;

            colors = new Color[numColors];
            colors[0] = Color.White;
            colors[1] = Color.Red;
            
            SourceRect[0] = new Rectangle(18, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(1, 11, 16, 16);
            this.Interval = 128f;
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public override void Update(GameTime gameTime)
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

            player.move(new Vector2(0, SpriteSpeed));
            this.FrameStep(gameTime);
            /*//Animate the sprites (pulled from animatedStillSprite.cs)
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
            }*/
        }

        /*public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame%FrameCount].Width*scale, SourceRect[CurrentFrame%FrameCount].Height*scale);
            
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);

        }*/

    }
}
