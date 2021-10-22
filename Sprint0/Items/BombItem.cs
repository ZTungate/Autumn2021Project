using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Sprint3.Items
{
    public class BombItem : AbstractItem
    {
        public BombItem(Rectangle rect) : base(ItemEnum.Bomb, rect)
        {

        }
    }
}
