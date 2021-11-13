using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    class Floor : AbstractBlock
    {
        public Floor(Point pos) : base(BlockType.Floor, pos)
        {
            Walkable = true;
        }
    }
}
