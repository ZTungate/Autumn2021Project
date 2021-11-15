using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class UpBlueArrowSprite : AbstractSprite
    {

        public UpBlueArrowSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(27, 185, 8, 16);  //Set the frame for right idle link
            this.Interval = 800;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
