using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class BladeTrapSprite : AbstractSprite
    {
        public BladeTrapSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            //Set the source rectangle
            SourceRect[0] = new Rectangle(164, 59, 16, 16);
        }
    }
}
