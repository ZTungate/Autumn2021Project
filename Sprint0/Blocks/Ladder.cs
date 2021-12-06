using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    class Ladder : AbstractBlock
    {
        public Ladder(Point pos) : base(BlockType.Ladder, pos)
        {
            Walkable = true;
        }
    }
}
