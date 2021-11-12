using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class ArrowItem : AbstractItem
    {
        public ArrowItem(Point pos) : base(ItemEnum.Arrow, pos, Point.Zero)
        {

        }
    }
}
