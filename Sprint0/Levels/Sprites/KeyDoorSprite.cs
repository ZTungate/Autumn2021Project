using System;
using System.Collections.Generic;
using System.Text;
using Sprint2;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Levels.Sprites
{
    class KeyDoorSprite : AbstractDoorSprite
    {
        public KeyDoorSprite(Texture2D spriteSheet, Vector2 Destination, float scaleX, float scaleY)
        {
            Texture = spriteSheet;
            SourceRect = new Rectangle[4];
            SourceRect[0] = new Rectangle(881, 11, 32, 32);
            SourceRect[1] = new Rectangle(881, 77, 32, 32);
            SourceRect[2] = new Rectangle(881, 110, 32, 32);
            SourceRect[3] = new Rectangle(881, 44, 32, 32);
            Position = Destination;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
        }
    }
}
