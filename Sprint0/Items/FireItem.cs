using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    class FireItem : AbstractItem
    {
        public FireItem(Point pos) : base(ItemEnum.Fire, pos, Point.Zero)
        {

        }
    }
}
