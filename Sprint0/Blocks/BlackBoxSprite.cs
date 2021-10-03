﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Blocks
{
    public class BlackBoxSprite : IBlocks
    {
        public Texture2D Texture { get; set; }
        public Rectangle sourceRect { get; set; }
        public Vector2 Position { get; set; }


        public BlackBoxSprite(Texture2D spriteSheet, Vector2 Destination)
        {
            Texture = spriteSheet;
            sourceRect = new Rectangle(33, 387, 16, 16);
            Position = Destination;
        }
        public void Draw(SpriteBatch spriteBatch) //TODO figure out where I want to actually draw this
        {
            Rectangle destRect = new Rectangle((int)Position.X, (int)Position.Y, sourceRect.Width*2, sourceRect.Height*2); //height adjustment just for visability
            spriteBatch.Draw(Texture, destRect, sourceRect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Does nothing since a floor tile doesn't need updated
        }
        
    }
}