using Poggus.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Collisions
{
    class I2ICollision : ICollision
    {
            public bool IsCollision { get; set; }
            public ColDirections direction { get; set; }

            public AbstractItem item1 { get; set; }

            public AbstractItem item2 { get; set; }

            public I2ICollision(ColDirections direction, bool IsCollision, AbstractItem item1, AbstractItem item2)
            {
                this.direction = direction;
                this.IsCollision = IsCollision;
                this.item1 = item1;
                this.item2 = item2;
            }
        
    }
}
