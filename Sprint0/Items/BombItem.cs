using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class BombItem : AbstractItem
    {
        public BombItem(Point pos) : base(ItemEnum.Bomb, pos, Point.Zero)
        {

        }
        
    }
}
