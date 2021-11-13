using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class CompassItem : AbstractItem
    {
        public CompassItem(Point pos) : base(ItemEnum.Compass, pos, Point.Zero)
        {

        }
    }
}
