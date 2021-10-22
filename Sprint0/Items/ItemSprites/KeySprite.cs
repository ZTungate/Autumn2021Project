﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint3.Items.ItemSprites
{
    public class KeySprite : AbstractItemSprite
    {
        public KeySprite(Texture2D spriteSheet)
        {
            Texture = spriteSheet;
            SourceRect = new Rectangle[1];

            SourceRect[0] = new Rectangle(240, 0, 8, 16);
        }
    }
}
