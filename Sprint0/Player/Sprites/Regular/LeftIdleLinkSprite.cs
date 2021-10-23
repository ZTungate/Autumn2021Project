using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class LeftIdleLinkSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        ILink player;

        public Color[] colors;
        int numColors = 2;






        public int scale = 2;

        public LeftIdleLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;

            colors = new Color[numColors];
            colors[0] = Color.White;
            colors[1] = Color.Red;

            SourceRect[0] = new Rectangle(35, 11, 16, 16);  //Set the frame for right idle link
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public override void Update(GameTime gameTime)
        {
            // Implement animation changes here
            /*if (player.isDamaged)
            {
                if(Timer > colorFlashInterval)
                {
                    colorIndex++;
                    Timer = 0;
                }
                else
                {
                    Timer += (float) gameTime.ElapsedGameTime.TotalMilliseconds;
                }
            }
            else
            {
                colorIndex = 0;
            }*/
            
        }

        /*public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width*scale, SourceRect[CurrentFrame].Height*scale);
            //Can use this format instead of the other one
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame%FrameCount], player.color, 0, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 1);
        }*/

    }
}
