using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Enemies;

namespace Poggus
{
    public class SkeletonSprite : AbstractSprite
    {
        public SkeletonSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            //Set the two frames for the skeleton animation
            SourceRect[0] = new Rectangle(404, 59, 16, 16);
            SourceRect[1] = new Rectangle(423, 59, 16, 16);

            this.Interval = 120;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
