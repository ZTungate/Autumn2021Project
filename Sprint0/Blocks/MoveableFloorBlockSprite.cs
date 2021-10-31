using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Blocks
{
    class MoveableFloorBlockSprite : IMoveableBlock
    {
        private Texture2D Texture { get; set; }
        public Rectangle sourceRect { get; set; }
        public Rectangle destRect { get; set; }

        public bool Walkable { get; }
        public MoveableFloorBlockSprite(Texture2D spriteSheet, Vector2 Destination)
        {
            Walkable = false;
            Texture = spriteSheet;
            sourceRect = new Rectangle(386, 49, 16, 16);
            destRect = new Rectangle((int)Destination.X, (int)Destination.Y, sourceRect.Width * 2, sourceRect.Height * 2); //height adjustment just for visability
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(Texture, destRect, sourceRect, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            //Does nothing since block doesn't need updated
        }

    }
}

