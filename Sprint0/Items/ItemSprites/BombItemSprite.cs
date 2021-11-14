using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Items.ItemSprites
{
    public class BombItemSprite : AbstractSprite
    {

        public BombItemSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(136, 0, 8, 14);
        }
    }
}
