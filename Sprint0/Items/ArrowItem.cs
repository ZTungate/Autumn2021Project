using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class ArrowItem : AbstractItem
    {
        public ArrowItem(Point pos) : base(ItemEnum.Arrow, pos, Point.Zero)
        {

        }
        
    }
}
