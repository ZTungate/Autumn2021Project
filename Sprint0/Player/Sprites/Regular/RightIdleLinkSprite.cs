using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class RightIdleLinkSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        ILink player;

        public int scale = 2;

        public RightIdleLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[1])
        {
            this.player = player;

            SourceRect[0] = new Rectangle(35, 11, 16, 16);  //Set the frame for right idle link
            /*Position = pos;*/     //Sets the position to Link's position
        }

        /*public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width*scale, SourceRect[CurrentFrame].Height*scale);
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);

        }*/

    }
}
