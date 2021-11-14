using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Collisions

{

    public enum ColDirections { North, South, East, West };

    public interface ICollision
    {
        

        bool IsCollision { get; set; }

        public ColDirections direction {get; set; }

    }
}
