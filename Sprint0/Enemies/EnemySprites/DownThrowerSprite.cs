﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Enemies;

namespace Poggus
{
    public class DownThrowerSprite : AbstractSprite
    {
        public DownThrowerSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            //Set the two frames for the animation
            SourceRect[0] = new Rectangle(222, 11, 16, 16);
            SourceRect[1] = new Rectangle(222, 28, 16, 16);
        }

    }
}
