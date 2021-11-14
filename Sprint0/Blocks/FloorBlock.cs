using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    class FloorBlock : AbstractBlock
    {
        public FloorBlock(Point pos) : base(BlockType.FloorBlock, pos)
        {
            Walkable = true;
        }
    }
}
