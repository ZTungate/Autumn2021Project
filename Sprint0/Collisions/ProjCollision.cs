using Sprint2.Player;
using Sprint2.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collisions
{
    class P2PCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IProjectile proj1 { get; set; }

        public IProjectile proj2 { get; set; }

        public P2PCollision(ColDirections direction, bool IsCollision, IProjectile proj1, IProjectile proj2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.proj1 = proj1;
            this.proj2 = proj2;
        }
    }

    class P2LCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IProjectile proj1 { get; set; }

        public ILink link2 { get; set; }

        public P2LCollision(ColDirections direction, bool IsCollision, IProjectile proj1, ILink link2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.proj1 = proj1;
            this.link2 = link2;
        }
    }
}
