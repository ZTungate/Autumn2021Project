using System;
using System.Collections.Generic;
using System.Text;
using Poggus;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Levels.Sprites
{
    public class DoorOverlaySprite : AbstractSprite
    {
        public DoorOverlaySprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            //UP
            SourceRect[0] = new Rectangle(848, 144, 32, 32);
            //RIGHT
            SourceRect[1] = new Rectangle(914, 145, 32, 32);
            //DOWN
            SourceRect[2] = new Rectangle(947, 145, 32, 32);
            //LEFT
            SourceRect[3] = new Rectangle(881, 144, 32, 32);
        }
    }
}
