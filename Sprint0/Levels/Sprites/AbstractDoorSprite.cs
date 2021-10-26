using System;
using System.Collections.Generic;
using System.Text;
using Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Levels.Sprites
{
    public class AbstractDoorSprite : ISprite
    {
        public float Timer { get; set; } = 0f;
        public float Interval { get; set; } = 0f;
        public int CurrentFrame { get; set; } = 0;
        public int FrameCount { get; set; } = 1;
        public float SpriteSpeed { get; set; } = 0;
        public Texture2D Texture { get; set; }
        public Rectangle[] SourceRect { get; set; }
        public Vector2 Position { get; set; }

        public Rectangle destRect;
        public float scaleX, scaleY;
        public void Draw(SpriteBatch spriteBatch) //TODO figure out where I want to actually draw this
        {
            destRect = new Rectangle((int)Position.X, (int)Position.Y, (int)(SourceRect[0].Width * scaleX), (int)(SourceRect[0].Height * scaleY)); //height adjustment just for visability

            spriteBatch.Draw(Texture, destRect, SourceRect[CurrentFrame], Color.White);
        }
        public void Update(GameTime gameTime)
        {
            //no-op
        }
    }
}
