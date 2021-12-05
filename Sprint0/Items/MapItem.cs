using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    class MapItem : AbstractItem
    {
        public MapItem(Point pos) : base(ItemEnum.Map, pos, Point.Zero)
        {

        }
    }
}
