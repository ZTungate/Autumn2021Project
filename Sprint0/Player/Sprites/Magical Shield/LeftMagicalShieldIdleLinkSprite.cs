using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Player
{
    public class LeftMagicalShieldIdleLinkSprite : AbstractSprite
    {

        public LeftMagicalShieldIdleLinkSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(323, 11, 16, 16);  //Set the frame for right idle link
            this.effects = SpriteEffects.FlipHorizontally;

        }

    }
}
