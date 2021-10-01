using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class OldManSprite : ISprite
    {
        public int CurrentFrame { get; set; } = 0;

        public int FrameCount { get; private set; } = 1;

        public float SpriteSpeed { get; set; } = 0;

        public Texture2D Texture { get; set; }

        public Rectangle[] SourceRect { get; set; }

        public Vector2 Position { get; set; }


        public OldManSprite(Texture2D SpriteSheet)
        {
            Texture = SpriteSheet;
            SourceRect = new Rectangle[1];

            SourceRect[0] = new Rectangle(1,11,16,16);

            //Dummy Position, will be replaced later.
            Position = new Vector2(500,100);
        }

        public void Update(GameTime gameTime)
        {
            //Static sprite, no updating needed.
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, SourceRect[CurrentFrame].Width, SourceRect[CurrentFrame].Height);
            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }

    }
}
