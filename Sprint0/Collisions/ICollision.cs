using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;

namespace Poggus.Collisions

{

    public enum ColDirections { North, South, East, West, None }; //Direction the object is hit from

    public interface ICollision
    {
        public static Point[] pointDirections = { new Point(0,1), new Point(0,-1), new Point(1,0), new Point(-1,0), Point.Zero };

        bool IsCollision { get; set; }

        public ColDirections direction {get; set; }

    }
}
