using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Items.ItemSprites
{
    public class TriforcePieceSprite : AbstractItemSprite
    {
        public TriforcePieceSprite(Texture2D spriteSheet)
        {
            Texture = spriteSheet;
            SourceRect = new Rectangle[2];

            Interval = 80f;
            FrameCount = 2;

            SourceRect[0] = new Rectangle(275, 3, 10, 10);
            SourceRect[1] = new Rectangle(275, 19, 10, 10);
        }
    }
}
