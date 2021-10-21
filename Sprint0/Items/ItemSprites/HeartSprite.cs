using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Items.ItemSprites
{
    public class HeartSprite : AbstractItemSprite
    {
        public HeartSprite(Texture2D spriteSheet)
        {
            Texture = spriteSheet;
            SourceRect = new Rectangle[2];

            SourceRect[0] = new Rectangle(0, 0, 7, 8);
            SourceRect[1] = new Rectangle(0, 8, 7, 8);
        }
    }
}
