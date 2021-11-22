using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Items.ItemSprites
{
    public class SwordSprite : AbstractSprite
    {
        public SwordSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(104, 0, 7, 16);
        }

    }
}

