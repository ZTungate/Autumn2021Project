using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class HeartItem : AbstractItem
    {
        public HeartItem(Point pos) : base(ItemEnum.Heart, pos, Point.Zero)
        {

        }
    }
}
