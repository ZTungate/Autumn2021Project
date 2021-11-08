using Poggus.Blocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Collisions
{
    class B2BCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IBlock block1 { get; set; }

        public IBlock block2 { get; set; }

        public B2BCollision(ColDirections direction, bool IsCollision, IBlock block1, IBlock block2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.block1 = block1;
            this.block2 = block2;
        }
    }
}
