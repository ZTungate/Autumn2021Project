using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Blocks
{
    class MoveableFloorBlock : AbstractBlock
    {
        public MoveableFloorBlock(Point pos) : base(BlockType.MoveableFloorBlock, pos)
        {
            this.Moveable = true;
        }
    }
}
