using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class BoomerangSprite : AbstractSprite
    {
        public BoomerangSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[8])
        {
            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(290, 15, 8, 8);
            SourceRect[1] = new Rectangle(299, 15, 8, 8);
            SourceRect[2] = new Rectangle(308, 15, 8, 8);
            SourceRect[3] = new Rectangle(317, 15, 8, 8);
            SourceRect[4] = new Rectangle(326, 15, 8, 8);
            SourceRect[5] = new Rectangle(335, 15, 8, 8);
            SourceRect[6] = new Rectangle(344, 15, 8, 8);
            SourceRect[7] = new Rectangle(353, 15, 8, 8);
            this.Interval = ProjectileConstants.boomerangAnimInterval;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
