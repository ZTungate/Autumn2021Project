using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus
{
    public class DownBlueArrowSprite : AbstractSprite
    {
        public DownBlueArrowSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(27, 185, 8, 16);  //Set the frame for right idle link
            SourceRect[1] = new Rectangle(53, 185, 8, 16);
            this.Interval = 800f;
            this.effects = SpriteEffects.FlipVertically;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
