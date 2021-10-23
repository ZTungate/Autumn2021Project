using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class BatSprite : AbstractSprite
    {
        public BatSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            //Set the two frames for the bat animation
            SourceRect[0] = new Rectangle(183, 11, 16, 16);
            SourceRect[1] = new Rectangle(200, 11, 16, 16);
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}
