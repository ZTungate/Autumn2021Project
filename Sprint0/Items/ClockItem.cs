using Microsoft.Xna.Framework;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Items
{
    public class ClockItem : AbstractItem
    {
        public ClockItem(Point pos) : base(ItemEnum.Clock, pos, Point.Zero)
        {
            
        }
        
    }
}
