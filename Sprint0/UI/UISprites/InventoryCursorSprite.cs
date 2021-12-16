using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UISprites
{
    public class InventoryCursorSprite : AbstractSprite
    {
        public InventoryCursorSprite(Texture2D texture) : base(texture, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(519, 137, 16, 16);
            IsUISprite = true;
        }
    }
}
