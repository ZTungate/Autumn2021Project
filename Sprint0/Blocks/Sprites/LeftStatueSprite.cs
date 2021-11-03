﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint2.Blocks
{
    public class LeftStatueSprite : AbstractSprite
    {
        public LeftStatueSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(659, 934, 16, 16);
        }
        
    }
}