using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Items.ItemSprites
{
    public class StationaryBoomerangSprite : AbstractSprite
    {
        public StationaryBoomerangSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(128, 2, 7, 10);
        }
    }
}
