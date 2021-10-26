using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint0.Player;

namespace Sprint2.Player
{
    public class DownUseItemLinkSprite : IAnimatedSprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 440f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 1;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        ILink player;

        public DownUseItemLinkSprite(Texture2D spriteSheet, ILink player)
        {
            this.player = player;

            Texture = spriteSheet;  //Set the texture2D to the provided spriteSheet (already initialized by factory)
            SourceRect = new Rectangle[1];

            SourceRect[0] = new Rectangle(107, 11, 16, 16);  //Set the frame for right idle link
            /*Position = pos;*/     //Sets the position to Link's position
        }

        public void Update(GameTime gameTime)
        {
            //No implementation needed.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width* (int)LinkConstants.scaleX, SourceRect[CurrentFrame].Height* (int)LinkConstants.scaleY);
            //spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, 0), (int)LinkConstants.scaleX, SpriteEffects.None, 1);

        }

    }
}
