using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Blocks
{
    class MoveableFloorBlockSprite : AbstractSprite
    {
        public MoveableFloorBlockSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(386, 49, 16, 16);
        }

    }
}

