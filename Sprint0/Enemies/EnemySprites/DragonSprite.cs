using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
using Poggus.Enemies;

namespace Poggus
{
    public class DragonSprite : AbstractSprite
    {
        public DragonSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            //Set the two frames for the slime animation
            SourceRect[0] = new Rectangle(1, 11, 24, 32);
            SourceRect[1] = new Rectangle(26, 11, 24, 32);
            SourceRect[2] = new Rectangle(51, 11, 24, 32);
            SourceRect[3] = new Rectangle(76, 11, 24, 32);
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }

    }
}
