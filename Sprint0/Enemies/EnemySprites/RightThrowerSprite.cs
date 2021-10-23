using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class RightThrowerSprite : AbstractSprite
    {
        public RightThrowerSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            //Set the two frames for the animation
            SourceRect[0] = new Rectangle(256, 11, 16, 16);
            SourceRect[1] = new Rectangle(273, 11, 16, 16);
        }

        public override void Update(GameTime gameTime)
        {
            //Animate the sprites (pulled from animatedStillSprite.cs)
            this.FrameStep(gameTime);
        }
    }
}
