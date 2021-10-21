using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2.Blocks;


namespace Sprint0.Collisions
{
    class CollisionDetection
    {



        public ICollision detectCollision(IBlocks object1, IBlocks object2)
        {
            Rectangle one = object1.destRect;
            Rectangle two = object2.destRect;
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location = ColDirections.North; //placeholder
            if(Overlap.Width <= Overlap.Height) //this would mean left-right collision
            {
                int check = one.X - two.X;
                if (check < 0) location = ColDirections.East; //right collision
                
                else location = ColDirections.West; //left collision

            }
            else //this means top-bottom collision 
            {
                int check = one.Y - two.Y;
                if (check < 0) location = ColDirections.South; //Bottom collision

                else location = ColDirections.North; //Top collision
            }
            ICollision collision = new GenCollision(location, one.Intersects(two));
            
            return collision;
        }
    }
}
