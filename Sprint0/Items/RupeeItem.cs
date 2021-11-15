using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class RupeeItem : AbstractItem
    {
        public RupeeItem(Point pos) : base(ItemEnum.Rupee, pos, Point.Zero)
        {

        }
        public override void useItem(ILink link) //TODO ask about this
        {
            link.LinkInventory.IncrementRupees();
        }
    }
}
