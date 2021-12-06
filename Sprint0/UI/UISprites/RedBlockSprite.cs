using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UISprites
{
    public class RedBlockSprite : AbstractSprite
    {
        public RedBlockSprite(Texture2D texture) : base(texture, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(8, 1, 1, 1);
            IsUISprite = true;
        }
    }
}
