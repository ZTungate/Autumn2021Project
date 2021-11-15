using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;

namespace Poggus.Items
{
    public class TriforcePieceItem : AbstractItem
    {
        public TriforcePieceItem(Point pos) : base(ItemEnum.TriforcePiece, pos, Point.Zero)
        {

        }

        public override void useItem(ILink link) //won't be used here to win game
        {
            
        }
    }
}
