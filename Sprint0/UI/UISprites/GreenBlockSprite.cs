﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UISprites
{
    public class GreenBlockSprite : AbstractSprite
    {
        public GreenBlockSprite(Texture2D texture) : base(texture, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(10, 0, 1, 1);
            IsUISprite = true;
        }
    }
}
