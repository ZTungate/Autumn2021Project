using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Blocks.Sprites
{
    class MoveableFloorBlockSprite : AbstractSprite
    {
        public MoveableFloorBlockSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(418, 435, 16, 16);
        }

    }
}

