using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Poggus.UI.UISprites
{
    public class InventoryBackgroundSprite : AbstractSprite
    {
        public InventoryBackgroundSprite(Texture2D texture) : base(texture, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(1, 11, 256, 88);
            IsUISprite = true;
        }
    }
}
