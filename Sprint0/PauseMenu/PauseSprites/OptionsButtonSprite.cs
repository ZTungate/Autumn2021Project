using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu.PauseSprites
{
    class OptionsButtonSprite : AbstractSprite
    {
        
            public OptionsButtonSprite(Texture2D texture) : base(texture, new Rectangle[3])
            {
                SourceRect[0] = new Rectangle(262, 254, 192, 32);
                SourceRect[1] = new Rectangle(459, 254, 192, 32);
                SourceRect[2] = new Rectangle(656, 254, 192, 32);
        }
        
    }
}
