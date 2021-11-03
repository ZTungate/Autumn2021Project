using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Enemies;

namespace Sprint2
{
    public class OldManSprite : AbstractSprite
    {
        public OldManSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(1,11,16,16);
        }

    }
}
