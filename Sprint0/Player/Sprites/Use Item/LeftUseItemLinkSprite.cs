using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint3.Player
{
    public class LeftUseItemLinkSprite : IAnimatedSprite
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

        public int scale = 2;

        public LeftUseItemLinkSprite(Texture2D spriteSheet, ILink player)
        {
            this.player = player;

            Texture = spriteSheet;  //Set the texture2D to the provided spriteSheet (already initialized by factory)
            SourceRect = new Rectangle[1];

            SourceRect[0] = new Rectangle(124, 11, 16, 16);  //Set the frame for right idle link
            //SourceRect[1] = new Rectangle(35, 11, 16, 16);  //Set the frame for right idle link

            /*Position = pos;*/     //Sets the position to Link's position

        }

        public void Update(GameTime gameTime)
        {
            //Non animated, no implementation needed.
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width*scale, SourceRect[CurrentFrame].Height*scale);
/*            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
*/            spriteBatch.Draw(Texture, player.position, SourceRect[CurrentFrame % FrameCount], player.color, 0, new Vector2(0, 0), scale, SpriteEffects.FlipHorizontally, 1);

        }

    }
}
