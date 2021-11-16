using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class SwordItem : AbstractItem
    {
        public SwordItem(Point pos) : base(ItemEnum.Sword, pos, Point.Zero)
        {

        }
        
    }
}
