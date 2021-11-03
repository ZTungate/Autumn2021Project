using System;
using System.Collections.Generic;
using System.Text;
using Sprint2;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sprint0.Levels.Sprites
{
    class HoleDoorSprite : AbstractSprite
    {
        public HoleDoorSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            SourceRect[0] = new Rectangle(947, 11, 32, 32);
            SourceRect[1] = new Rectangle(947, 77, 32, 32);
            SourceRect[2] = new Rectangle(947, 110, 32, 32);
            SourceRect[3] = new Rectangle(947, 44, 32, 32);
        }
    }
}
