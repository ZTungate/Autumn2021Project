﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class KeyItem : AbstractItem
    {
        public KeyItem(Point pos) : base(ItemEnum.Key, pos, Point.Zero)
        {

        }
    }
}
