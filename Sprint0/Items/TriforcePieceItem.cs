using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Items
{
    public class TriforcePieceItem : AbstractItem
    {
        public TriforcePieceItem(Point pos) : base(ItemEnum.TriforcePiece, pos, Point.Zero)
        {

        }
    }
}
