using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class BombItem : AbstractItem
    {
        public BombItem(Point pos) : base(ItemEnum.Bomb, pos, Point.Zero)
        {

        }
    }
}
