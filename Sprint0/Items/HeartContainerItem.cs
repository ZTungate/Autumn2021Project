using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class HeartContainerItem : AbstractItem
    {
        public HeartContainerItem(Point pos) : base(ItemEnum.HeartContainer, pos, Point.Zero)
        {

        }
    }
}
