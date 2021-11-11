using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class LeftBlueArrowSprite : AbstractSprite
    {
        public LeftBlueArrowSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(36, 189, 16, 8);//Horizontal Blue Arrow
            SourceRect[1] = new Rectangle(53, 189, 8, 8);//Poof
            this.effects = SpriteEffects.FlipHorizontally;
            this.Interval = 800;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
