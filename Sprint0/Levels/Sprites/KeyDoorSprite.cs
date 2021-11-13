using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Levels.Sprites
{
    class KeyDoorSprite : AbstractSprite
    {
        public KeyDoorSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            SourceRect[0] = new Rectangle(881, 11, 32, 32);
            SourceRect[1] = new Rectangle(881, 77, 32, 32);
            SourceRect[2] = new Rectangle(881, 110, 32, 32);
            SourceRect[3] = new Rectangle(881, 44, 32, 32);
        }
    }
}
