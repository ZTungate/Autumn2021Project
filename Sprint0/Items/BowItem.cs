using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Items
{
    public class BowItem : AbstractItem
    {
        public BowItem(NonAnimatedStillSprite sprite) : base(sprite)
        {

        }
        public override void Update(GameTime gameTime)
        {
            //Temporary just to set sprite location for testing
            this.sprite.Position = new Vector2(60, 50);
            base.Update(gameTime);
        }
    }
}
