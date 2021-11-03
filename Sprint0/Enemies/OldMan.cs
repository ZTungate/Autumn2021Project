using Microsoft.Xna.Framework;
using Sprint2.Helpers;
using Sprint2;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class OldMan : AbstractEnemy
    {
        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;
            Sprite.Update(gameTime);
        }

        public OldMan(Point pos) : base(pos, Point.Zero)
        {

        }

    }
}
