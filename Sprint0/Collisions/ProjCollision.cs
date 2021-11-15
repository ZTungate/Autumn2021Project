using Microsoft.Xna.Framework;
using Poggus.Blocks;
using Poggus.Enemies;
using Poggus.Player;
using Poggus.Projectiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Collisions
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

    class P2BCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IProjectile proj1 { get; set; }

        public IBlock block2 { get; set; }

        public P2BCollision(ColDirections direction, bool IsCollision, IProjectile proj1, IBlock block2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.proj1 = proj1;
            this.block2 = block2;
        }
    }

    class P2ECollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IProjectile proj1 { get; set; }

        public IEnemy enemy2 { get; set; }

        public P2ECollision(ColDirections direction, bool IsCollision, IProjectile proj1, IEnemy enemy2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.proj1 = proj1;
            this.enemy2 = enemy2;
        }
    }

    class P2RCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public IProjectile proj1 { get; set; }

        public Rectangle rectangle2 { get; set; }

        public P2RCollision(ColDirections direction, bool IsCollision, IProjectile proj1, Rectangle rectangle2)
        {
            this.direction = direction;
            this.IsCollision = IsCollision;
            this.proj1 = proj1;
            this.rectangle2= rectangle2;
        }
    }
}
