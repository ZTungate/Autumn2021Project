using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class ArrowPoofSprite : AbstractSprite
    {
        public ArrowPoofSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(53, 185, 8, 16);
            this.Interval = 200;
        }

        public override void Update(GameTime gameTime)
        {
        }
    }

}
