using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Items.ItemSprites
{
    public class CompassSprite : AbstractItemSprite
    {
        public CompassSprite(Texture2D spriteSheet)
        {
            Texture = spriteSheet;
            SourceRect = new Rectangle[1];

            SourceRect[0] = new Rectangle(257, 0, 13, 14);
        }
    }
}
