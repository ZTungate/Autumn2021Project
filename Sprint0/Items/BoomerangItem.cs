using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class BoomerangItem : AbstractItem
    {
        public BoomerangItem(Point pos) : base(ItemEnum.Boomerang, pos, Point.Zero)
        {

        }
        
    }
}
