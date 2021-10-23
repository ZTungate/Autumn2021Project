using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class PickUpLinkSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int scale = 2;

        Link player;
        public PickUpLinkSprite(Texture2D spriteSheet, Link player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;
            SourceRect[0] = new Rectangle(213 , 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(230, 11, 16, 16);
            this.Interval = 128f;
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public void Update(GameTime gameTime)
        {
            // Implement animation changes here
            this.FrameStep(gameTime);
        }

        /*public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame%FrameCount].Width*scale, SourceRect[CurrentFrame%FrameCount].Height*scale);
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], Color.White, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);

        }*/

    }
}
