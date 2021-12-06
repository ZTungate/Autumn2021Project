using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Poggus.Player;
using Poggus;
using Poggus.Blocks;
using Poggus.Enemies;
using Poggus.Items;
using Poggus.Projectiles;

namespace Poggus.Collisions
{
    public class CollisionDetection
    {
        public CollisionDetection()
        {

        }
        private ColDirections directionDetect(Rectangle one, Rectangle two)
        {
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location; //placeholder
            if (Overlap.Width <= Overlap.Height) //this would mean left-right collision
            {
                int check = one.X - two.X;
                if (check < 0) location = ColDirections.West; //Left collision

                else location = ColDirections.East; //Right collision
            }
            else //this means top-bottom collision 
            {
                int check = one.Y - two.Y;
                if (check < 0) location = ColDirections.North; //Top collision

                else location = ColDirections.South; //Bottom collision
            }

            return location;
        }
        //heavilly overloaded to check collisions, all will return a concrete type for the specific objects coming in
        //Rectangle setup logic varries based on whether implementaion uses Vector or Rect. TODO Change to rectangle implementation everywhere (Will take time)
        public ICollision detectCollision(IBlock object1, IBlock object2) //returns B2B Collision
        {
            Rectangle one = object1.DestRect;
            Rectangle two = object2.DestRect;
            ICollision collision = new B2BCollision(directionDetect(one, two), one.Intersects(two), object1, object2);
           
            return collision;
        }

        public ICollision detectCollision(IEnemy object1, IEnemy object2) //returns E2E Collision
        {
            ICollision collision = new E2ECollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object1, object2);
         
            return collision;
        }

        public ICollision detectCollision(IEnemy object1, IBlock object2) 
        {
            ICollision collision = new E2BCollision(directionDetect(object1.ColliderRect, object2.DestRect), object1.ColliderRect.Intersects(object2.DestRect), object1, object2);
          
            return collision;
        }

        public ICollision detectCollision(ILink object1, IEnemy object2) 
        {
            ICollision collision = new L2ECollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object1, object2);
          
            return collision;
        }

        public ICollision detectCollision(IEnemy object1, ILink object2) 
        {
            ICollision collision = new L2ECollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object2, object1);
           
            return collision;
        }

        public ICollision detectCollision(ILink object1, IBlock object2) 
        {
            ICollision collision = new L2BCollision(directionDetect(object1.ColliderRect, object2.DestRect), object1.ColliderRect.Intersects(object2.DestRect), object1, object2);
           
            return collision;
        }
        //Returns L2R collision
        public ICollision detectCollision(ILink object1, Rectangle object2)
        {
            ICollision collision = new L2RCollision(directionDetect(object1.ColliderRect, object2), object1.ColliderRect.Intersects(object2), object1, object2);
            
            return collision;
        }

        //Returns E2R collision
        public ICollision detectCollision(IEnemy object1, Rectangle object2)
        {
            ICollision collision = new E2RCollision(directionDetect(object1.ColliderRect, object2), object1.ColliderRect.Intersects(object2), object1, object2);
            
            return collision;
        }

        public ICollision detectCollision(IBlock object1, ILink object2) 
        {
            ICollision collision = new L2BCollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object2, object1);
           
            return collision;
        }

        public ICollision detectCollision(ILink object1, AbstractItem object2) 
        {
            ICollision collision = new L2ICollision(directionDetect(object1.DestRect, object2.GetRectangle()), object1.DestRect.Intersects(object2.GetRectangle()), object1, object2);
            
            return collision;
        }

        public ICollision detectCollision(AbstractItem object1, ILink object2) 
        {
            ICollision collision = new L2ICollision(directionDetect(object1.GetRectangle(), object2.DestRect), object1.GetRectangle().Intersects(object2.DestRect), object2, object1);
           
            return collision;
        }

        public ICollision detectCollision(AbstractItem object1, AbstractItem object2) 
        {
            Rectangle one = object1.GetRectangle();
            Rectangle two = object2.GetRectangle();
            
            ICollision collision = new I2ICollision(directionDetect(one, two), one.Intersects(two), object1, object2);

            return collision;
        }

        public ICollision detectCollision(AbstractItem object1, IEnemy object2) 
        {
            ICollision collision = new E2ICollision(directionDetect(object1.GetRectangle(), object2.DestRect), object1.GetRectangle().Intersects(object2.DestRect), object2, object1);
            
            return collision;
        }

        public ICollision detectCollision(IEnemy object1, AbstractItem object2)
        {
            ICollision collision = new E2ICollision(directionDetect(object1.DestRect, object2.GetRectangle()), object1.DestRect.Intersects(object2.GetRectangle()), object1, object2);

            return collision;
        }

        public ICollision detectCollision(IProjectile object1, IProjectile object2) 
        {
            ICollision collision = new P2PCollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object1, object2);

            return collision;
        }
        public ICollision detectCollision(ILink object1, IProjectile object2) 
        {
            
            ICollision collision = new P2LCollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object2, object1);

            return collision;
        }

        public ICollision detectCollision(IProjectile object1, ILink object2) 
        {
            ICollision collision = new P2LCollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object1, object2);

            return collision;
        }

        public ICollision detectCollision(IBlock object1, IProjectile object2) 
        {
            ICollision collision = new P2BCollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object2, object1);

            return collision;
        }

        public ICollision detectCollision(IProjectile object1, IBlock object2) 
        {
            ICollision collision = new P2BCollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object1, object2);

            return collision;
        }
        public ICollision detectCollision(IProjectile object1, IEnemy object2) 
        {
            ICollision collision = new P2ECollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object1, object2);

            return collision;
        }

        public ICollision detectCollision(IEnemy object1, IProjectile object2)
        {
            ICollision collision = new P2ECollision(directionDetect(object1.DestRect, object2.DestRect), object1.DestRect.Intersects(object2.DestRect), object2, object1);

            return collision;
        }

        public ICollision detectCollision(IProjectile proj, Rectangle rectangle)
        {
            ICollision collision= new P2RCollision(directionDetect(proj.DestRect, rectangle), proj.DestRect.Intersects(rectangle), proj, rectangle);
           
            return collision;
        }
    }
}
