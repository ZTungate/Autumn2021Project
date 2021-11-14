using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Items.ItemSprites
{
    public class BowSprite : AbstractSprite
    {
        public BowSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(144, 0, 8, 16);
        }

    }
}
