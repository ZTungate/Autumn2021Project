using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class RightBlueArrowSprite : AbstractSprite
    {
        public RightBlueArrowSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[1])
        {
            SourceRect[0] = new Rectangle(36, 189, 16, 8); //Horizontal Blue Arrow
            this.Interval = 800;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
