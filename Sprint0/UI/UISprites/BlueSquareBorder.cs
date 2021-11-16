using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UISprites
{
    public class BlueSquareBorderSprite : AbstractSprite
    {
        public BlueSquareBorderSprite(Texture2D texture) : base(texture, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(11, 0, 125, 50);
            IsUISprite = true;
        }
    }
}
