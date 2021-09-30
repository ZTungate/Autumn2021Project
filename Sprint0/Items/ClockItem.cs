using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Items
{
    public class ClockItem : AbstractItem
    {
        public ClockItem(NonAnimatedStillSprite sprite) : base (sprite)
        {

        }
        public override void Update(GameTime gameTime)
        {
            //Temporary just to set sprite location for testing
            this.sprite.Position = new Vector2(50, 50);
            base.Update(gameTime);
        }
    }
}
