using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu.PauseSprites
{
    class ResumeButtonSprite : AbstractSprite
    {
        
            public ResumeButtonSprite(Texture2D texture) : base(texture, new Rectangle[3])
            {
                SourceRect[0] = new Rectangle(262, 214, 192, 32);
                SourceRect[1] = new Rectangle(459, 214, 192, 32);
                SourceRect[2] = new Rectangle(656, 214, 192, 32);
        }
        
    }
}
