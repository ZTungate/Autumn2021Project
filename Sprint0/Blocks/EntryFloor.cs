using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    class EntryFloor : AbstractBlock
    {
        public EntryFloor(Point pos) : base(BlockType.EntryFloor, pos)
        {
            Walkable = true;
        }
    }
}
