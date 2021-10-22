using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Items.ItemSprites
{
    public class FairySprite : AbstractItemSprite
    {
        public FairySprite(Texture2D spriteSheet)
        {
            Texture = spriteSheet;
            SourceRect = new Rectangle[2];

            Interval = 80f;
            FrameCount = 2;

            SourceRect[0] = new Rectangle(40, 0, 8, 16);
            SourceRect[1] = new Rectangle(48, 0, 8, 16);
        }
    }
}
