using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Enemies;

namespace Poggus
{
    public class SlimeSprite : AbstractSprite
    {
        public SlimeSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(1, 11, 8, 16);
            SourceRect[1] = new Rectangle(10, 11, 8, 16);
            this.Interval = 120;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}
