using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2
{
    public class DownRightSwordExplosionSprite : AbstractSprite
    {
        public DownRightSwordExplosionSprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[4])
        {
            SourceRect[0] = new Rectangle(27, 154, 8, 16);  //Set the frame for sword
            SourceRect[1] = new Rectangle(62, 154, 8, 16);
            SourceRect[2] = new Rectangle(97, 154, 8, 16);
            SourceRect[3] = new Rectangle(132, 154, 8, 16);
            this.Interval = 50f;
            this.effects = SpriteEffects.FlipVertically | SpriteEffects.FlipHorizontally;
        }

        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }

}
