using Sprint2.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collisions
{
    class B2BCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IBlocks block1 { get; set; }

        public IBlocks block2 { get; set; }

        public B2BCollision(ColDirections direction, bool IsCollision, IBlocks block1, IBlocks block2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.block1 = block1;
            this.block2 = block2;
        }
    }
}
