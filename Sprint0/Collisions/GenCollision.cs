using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Collisions
{
    class GenCollision : ICollision
    {
        public bool IsCollision { get; set; }
        public ColDirections direction { get; set; }

        public GenCollision(ColDirections direction, bool IsCollision)
        {

        }
    }
}
