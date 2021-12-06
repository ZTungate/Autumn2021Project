using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    class Stair : AbstractBlock
    {
        public Point referenceLevelPoint;
        public Stair(Point pos) : base(BlockType.Stair, pos)
        {
            Walkable = true;
        }
    }
}
