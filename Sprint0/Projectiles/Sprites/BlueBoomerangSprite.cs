using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class BlueBoomerangSprite : AbstractSprite
    {
        public BlueBoomerangSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[3])
        {
            //Set the 8 source rectangles for the boomerang animation
            SourceRect[0] = new Rectangle(91, 189, 8, 8);
            SourceRect[1] = new Rectangle(100, 189, 8, 8);
            SourceRect[2] = new Rectangle(109, 189, 8, 8);
            this.Interval = ProjectileConstants.boomerangAnimInterval;

        }

        public override void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            this.FrameStep(gameTime);
        }
    }

}
