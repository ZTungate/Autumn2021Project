using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint0.Player;
using Sprint2;
using Sprint2.Blocks;
using Sprint2.Enemies;
using Sprint2.Items;
using Sprint2.Player;
using Sprint2.Projectiles;

namespace Sprint0.Collisions
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
            Rectangle one = object1.destRect;
            Rectangle two = object2.destRect;
            ICollision collision = new B2BCollision(directionDetect(one, two), one.Intersects(two), object1, object2);
            return collision;
        }

        public ICollision detectCollision(IEnemy object1, IEnemy object2) //returns E2E Collision
        {
            Vector2 holder1 = object1.Position;
            Vector2 holder2 = object2.Position;
            
            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int)EnemyConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * (int)EnemyConstants.scaleX, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);
            ICollision collision = new E2ECollision(directionDetect(one, two), one.Intersects(two), object1, object2);
            return collision;
        }

        public ICollision detectCollision(IEnemy object1, IBlock object2) 
        {
            Vector2 holder1 = object1.Position;
            

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int) EnemyConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);
            Rectangle two = object2.destRect;
            ICollision collision = new E2BCollision(directionDetect(one, two), one.Intersects(two), object1, object2);
            return collision;
        }

        public ICollision detectCollision(ILink object1, IEnemy object2) 
        {
            Vector2 holder1 = object1.position;
            Vector2 holder2 = object2.Position;
            
            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * 2, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * 2);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * (int) EnemyConstants.scaleX, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * (int) EnemyConstants.scaleY);
            ICollision collision = new L2ECollision(directionDetect(one, two), one.Intersects(two), object1, object2);
            return collision;
        }

        public ICollision detectCollision(IEnemy object1, ILink object2) 
        {
            Vector2 holder1 = object1.Position;
            Vector2 holder2 = object2.position;

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int)EnemyConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            ICollision collision = new L2ECollision(directionDetect(one, two), one.Intersects(two), object2, object1);
            return collision;
        }

        public ICollision detectCollision(ILink object1, IBlock object2) 
        {
            Vector2 holder1 = object1.position;


            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            Rectangle two = object2.destRect;
            ICollision collision = new L2BCollision(directionDetect(one, two), one.Intersects(two), object1, object2);
            return collision;
        }
        //Returns L2R collision
        public ICollision detectCollision(ILink object1, Rectangle object2)
        {
            Vector2 holder1 = object1.position;

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            Rectangle two = object2;
            ICollision collision = new L2RCollision(directionDetect(one, two), one.Intersects(two), object1, object2);
            return collision;
        }

        public ICollision detectCollision(IBlock object1, ILink object2) 
            {
                Vector2 holder1 = object2.position;


                Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
                Rectangle two = object1.destRect;
                ICollision collision = new L2BCollision(directionDetect(one, two), one.Intersects(two), object2, object1);
                return collision;
            }

            public ICollision detectCollision(ILink object1, AbstractItem object2) 
        {
            Vector2 holder1 = object1.position;
            
            
            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            Rectangle two = object2.GetRectangle();
            ICollision collision = new L2ICollision(directionDetect(one, two), one.Intersects(two), object1, object2);

            return collision;
        }

        public ICollision detectCollision(AbstractItem object1, ILink object2) 
        {
            Vector2 holder1 = object2.position;


            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            Rectangle two = object1.GetRectangle();
            ICollision collision = new L2ICollision(directionDetect(one, two), one.Intersects(two), object2, object1);

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
            Vector2 holder2 = object2.Position;


            Rectangle one = object1.GetRectangle();
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * (int)EnemyConstants.scaleX, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);
            
            ICollision collision = new E2ICollision(directionDetect(one, two), one.Intersects(two), object2, object1);

            return collision;
        }

        public ICollision detectCollision(IEnemy object1, AbstractItem object2)
        {
            Vector2 holder2 = object1.Position;


            Rectangle one = object2.GetRectangle();
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int)EnemyConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);

            ICollision collision = new E2ICollision(directionDetect(one, two), one.Intersects(two), object1, object2);

            return collision;
        }

        public ICollision detectCollision(IProjectile object1, IProjectile object2) 
        {
            Vector2 holder1 = object1.Position;
            Vector2 holder2 = object2.Position;

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * 2, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * 2);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * 2, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * 2);

            ICollision collision = new P2PCollision(directionDetect(one, two), one.Intersects(two), object1, object2);

            return collision;
        }
        public ICollision detectCollision(ILink object1, IProjectile object2) 
        {
            Vector2 holder1 = object1.position;
            Vector2 holder2 = object2.Position;

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            
            ICollision collision = new P2LCollision(directionDetect(one, two), one.Intersects(two), object2, object1);

            return collision;
        }

        public ICollision detectCollision(IProjectile object1, ILink object2) 
        {
            Vector2 holder1 = object1.Position;
            Vector2 holder2 = object2.position;

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object2.sprite.SourceRect[object2.sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);

            ICollision collision = new P2LCollision(directionDetect(one, two), one.Intersects(two), object1, object2);

            return collision;
        }

        public ICollision detectCollision(IBlock object1, IProjectile object2) 
        {
            
            Vector2 holder2 = object2.Position;

            Rectangle one = object1.destRect; 
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * (int)LinkConstants.scaleY, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            
            ICollision collision = new P2BCollision(directionDetect(one, two), one.Intersects(two), object2, object1);

            return collision;
        }

        public ICollision detectCollision(IProjectile object1, IBlock object2) 
        {

            Vector2 holder2 = object1.Position;

            Rectangle one = object2.destRect;
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);

            ICollision collision = new P2BCollision(directionDetect(one, two), one.Intersects(two), object1, object2);

            return collision;
        }
        public ICollision detectCollision(IProjectile object1, IEnemy object2) 
        {
            Vector2 holder1 = object1.Position;
            Vector2 holder2 = object2.Position;

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * (int)EnemyConstants.scaleX, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);
            ICollision collision = new P2ECollision(directionDetect(one, two), one.Intersects(two), object1, object2);

            return collision;
        }

        public ICollision detectCollision(IEnemy object1, IProjectile object2)
        {
            Vector2 holder1 = object2.Position;
            Vector2 holder2 = object1.Position;

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * (int)EnemyConstants.scaleX, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * (int)EnemyConstants.scaleY);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * (int)LinkConstants.scaleX, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * (int)LinkConstants.scaleY);
            ICollision collision = new P2ECollision(directionDetect(one, two), one.Intersects(two), object2, object1);

            return collision;
        }
    }
}
