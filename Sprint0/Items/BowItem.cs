using Microsoft.Xna.Framework;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Items
{
    public class BowItem : AbstractItem
    {
        public BowItem(Point pos) : base(ItemEnum.Bow, pos, Point.Zero)
        {

        }
        
    }
}
