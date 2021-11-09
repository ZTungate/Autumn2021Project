using Microsoft.Xna.Framework;
using Poggus.Helpers;
using Poggus;
using Poggus.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Enemies
{
    public class OldMan : AbstractEnemy
    {
        public override void Update(GameTime gameTime)
        {
            oldPosition = DestRect.Location;
            Sprite.Update(gameTime);
        }

        public OldMan(Point pos) : base(pos, new Point(32, 32))
        {

        }

    }
}
