using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Player
{
    public class UpMovingLinkSprite : AbstractSprite
    {
        public Vector2 Position { get; set; }

        public int scale = 2;

        ILink player;

        public UpMovingLinkSprite(Texture2D spriteSheet, ILink player) : base(spriteSheet, new Rectangle[2])
        {
            this.player = player;

            SourceRect[0] = new Rectangle(86, 11, 16, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(69, 11, 16, 16);
            this.Interval = 128;
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public override void Update(GameTime gameTime)
        {
            // Implement animation changes here

            player.move(new Vector2(0, -SpriteSpeed));
            this.FrameStep(gameTime);
        }

        /*public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame%FrameCount].Width*scale, SourceRect[CurrentFrame%FrameCount].Height*scale);
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, 0), scale, SpriteEffects.None, 1);

        }*/

    }
}
