using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Items.ItemSprites
{
    public class TriforcePieceSprite : AbstractSprite
    {
        public TriforcePieceSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(275, 3, 10, 10);
            SourceRect[1] = new Rectangle(275, 19, 10, 10);
            Interval = 128f;
        }
    }
}
