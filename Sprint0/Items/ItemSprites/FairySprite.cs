using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Poggus.Items.ItemSprites
{
    public class FairySprite : AbstractSprite
    {
        public FairySprite(Texture2D spriteSheet) : base(spriteSheet, new Rectangle[2])
        {
            SourceRect[0] = new Rectangle(40, 0, 8, 16);
            SourceRect[1] = new Rectangle(48, 0, 8, 16);
            Interval = 80f;
        }
        public override void Update(GameTime gameTime)
        {
            this.FrameStep(gameTime);
        }
    }
}
