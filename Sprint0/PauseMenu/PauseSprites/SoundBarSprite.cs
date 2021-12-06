using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.PauseMenu.PauseSprites
{
    class SoundBarSprite : AbstractSprite
    {
        
            public SoundBarSprite(Texture2D texture) : base(texture, new Rectangle[5])
            {
                SourceRect[0] = new Rectangle(550, 435, 19, 16);
                SourceRect[1] = new Rectangle(504, 431, 41, 20);
                SourceRect[2] = new Rectangle(443, 427, 56, 24);
                SourceRect[3] = new Rectangle(362, 423, 76, 28);
                SourceRect[4] = new Rectangle(262, 419, 95, 32);
        }
        
    }
}
