using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UISprites
{
    public class BlueBorderSprite : AbstractSprite
    {
        public BlueBorderSprite(Texture2D texture) : base(texture, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(0, 0, 8, 8);
            IsUISprite = true;
        }
    }
}
