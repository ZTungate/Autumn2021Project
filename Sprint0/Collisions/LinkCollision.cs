using Sprint2.Blocks;
using Sprint2.Enemies;
using Sprint2.Items;
using Sprint2.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collisions
{
    class L2ECollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public ILink Link1 { get; set; }

        public IEnemy enemy2 { get; set; }

        public L2ECollision(ColDirections direction, bool IsCollision, ILink enemy1, IEnemy enemy2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.Link1 = enemy1;
            this.enemy2 = enemy2;
        }
    }

    class L2BCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public ILink Link1 { get; set; }

        public IBlocks block2 { get; set; }

        public L2BCollision(ColDirections direction, bool IsCollision, ILink Link1, IBlocks Block2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.Link1 = Link1;
            this.block2 = Block2;
        }
    }

    class L2ICollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public ILink Link1 { get; set; }

        public AbstractItem Item2 { get; set; }

        public L2ICollision(ColDirections direction, bool IsCollision, ILink Link1, AbstractItem Item2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.Link1 = Link1;
            this.Item2 = Item2;
        }
    }
}
