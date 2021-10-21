using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Blocks;


namespace Sprint0.Collisions
{
    class CollisionDetection : ICollision
    {

        bool Collision;

        ColDirections side;
        public bool IsCollision { get => Collision; set => Collision = value; }


        public ColDirections direction { get => side; set => side = value; }


        public ICollision detectCollision(IBlocks object1, IBlocks object2)
        {
            
            
            return null;
        }
    }
}
