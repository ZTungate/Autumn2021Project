using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class FairyItem : AbstractItem
    {
        public FairyItem(Point pos) : base(ItemEnum.Fairy, pos, Point.Zero)
        {

        }
    }
}
