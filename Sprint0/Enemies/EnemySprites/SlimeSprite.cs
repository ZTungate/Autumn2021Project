using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Sprint2.Enemies;

namespace Sprint2
{
    public class SlimeSprite : AbstractSprite
    {
        public SlimeSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(1, 11, 8, 16);
            SourceRect[1] = new Rectangle(10, 11, 8, 16);
            this.Interval = 40;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}
