using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Player;

namespace Sprint2.Player
{
    public class UpSwordLinkSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 64f; 
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 5;
        public float SpriteSpeed { get; set; } = 1;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        ILink player;
        public UpSwordLinkSprite(Texture2D spriteSheet, ILink player)
        {
            this.player = player;

            Texture = spriteSheet;  //Set the texture2D to the provided spriteSheet (already initialized by factory)
            SourceRect = new Rectangle[5];
            
            SourceRect[0] = new Rectangle(1, 97, 16, 27);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(18, 97, 16, 27);
            SourceRect[2] = new Rectangle(35, 97, 16, 27);
            SourceRect[3] = new Rectangle(52, 97, 16, 27);
            SourceRect[4] = new Rectangle(69, 11, 16, 16);  //Set the frame for right idle link

            /*Position = pos;*/     //Sets the position to Link's position
        }

        public void Update(GameTime gameTime)
        {
            // Implement animation changes here
            //Animate the sprites (pulled from animatedStillSprite.cs)
            if (CurrentFrame < 4) {
                if (Timer > Interval) {
                    CurrentFrame++;


                    if (CurrentFrame > FrameCount - 1) {
                        CurrentFrame = 0;
                    }

                    Timer = 0;
                }
                else {
                    //Increment timer by the elapsed time in game.
                    Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            /*Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame%FrameCount].Width* (int)LinkConstants.scaleX, SourceRect[CurrentFrame%FrameCount].Height* (int)LinkConstants.scaleY);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);*/
            spriteBatch.Draw(Texture, new Vector2(player.position.X, player.position.Y + 16*(int)LinkConstants.scaleX), SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, SourceRect[CurrentFrame % FrameCount].Height), (int)LinkConstants.scaleX, SpriteEffects.None, 1);

        }

    }
}
