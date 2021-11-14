using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.Levels
{
    class BackgroundSprite : AbstractSprite
    {
        public BackgroundSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(1, 178, 256, 176);
        }
    }
}
