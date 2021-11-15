using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class CompassItem : AbstractItem
    {
        public CompassItem(Point pos) : base(ItemEnum.Compass, pos, Point.Zero)
        {

        }
        
    }
}
