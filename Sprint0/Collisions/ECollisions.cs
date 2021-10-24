using Sprint2.Blocks;
using Sprint2.Enemies;
using Sprint2.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collisions
{
    class E2BCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IEnemy enemy1 { get; set; }

        public IBlocks block2 { get; set; }

        public E2BCollision(ColDirections direction, bool IsCollision, IEnemy enemy1, IBlocks block2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.enemy1 = enemy1;
            this.block2 = block2;
        }
    }

    class E2ECollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IEnemy enemy1 { get; set; }

        public IEnemy enemy2 { get; set; }

        public E2ECollision(ColDirections direction, bool IsCollision, IEnemy enemy1, IEnemy enemy2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.enemy1 = enemy1;
            this.enemy2 = enemy2;
        }
    }

    class E2ICollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IEnemy enemy1 { get; set; }

        public AbstractItem item2 { get; set; }

        public E2ICollision(ColDirections direction, bool IsCollision, IEnemy enemy1, AbstractItem item2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.enemy1 = enemy1;
            this.item2 = item2;
        }
    }
}
