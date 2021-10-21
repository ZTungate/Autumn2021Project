using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Sprint2;
using Sprint2.Blocks;
using Sprint2.Enemies;
using Sprint2.Items;
using Sprint2.Player;

namespace Sprint0.Collisions
{
    class CollisionDetection
    {



        public ICollision detectCollision(IBlocks object1, IBlocks object2)
        {
            Rectangle one = object1.destRect;
            Rectangle two = object2.destRect;
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location; //placeholder
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

        public ICollision detectCollision(IEnemy object1, IEnemy object2) //Collisions between enemies similar logic different set up due to differences
        {
            Vector2 holder1 = object1.Position;
            Vector2 holder2 = object2.Position;
            
            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * 2, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * 2);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * 2, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * 2); 
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location; //placeholder
            if (Overlap.Width <= Overlap.Height) //this would mean left-right collision
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

        public ICollision detectCollision(IEnemy object1, IBlocks object2) //Collisions between enemies similar logic different set up due to differences
        {
            Vector2 holder1 = object1.Position;
            

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Width * 2, object1.Sprite.SourceRect[object1.Sprite.CurrentFrame].Height * 2);
            Rectangle two = object2.destRect; 
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location; //placeholder
            if (Overlap.Width <= Overlap.Height) //this would mean left-right collision
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

        public ICollision detectCollision(ILink object1, IEnemy object2) //Collisions between enemies similar logic different set up due to differences
        {
            Vector2 holder1 = object1.position;
            Vector2 holder2 = object2.Position;
            
            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * 2, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * 2);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Width * 2, object2.Sprite.SourceRect[object2.Sprite.CurrentFrame].Height * 2); 
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location; //placeholder
            if (Overlap.Width <= Overlap.Height) //this would mean left-right collision
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

        public ICollision detectCollision(ILink object1, IBlocks object2) //Collisions between enemies similar logic different set up due to differences
        {
            Vector2 holder1 = object1.position;
            

            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * 2, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * 2);
            Rectangle two = object2.destRect;
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location; //placeholder
            if (Overlap.Width <= Overlap.Height) //this would mean left-right collision
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

        public ICollision detectCollision(ILink object1, ISprite object2, ArrowItem test) //Collisions between enemies similar logic different set up due to differences
        {
            Vector2 holder1 = object1.position;
            Vector2 holder2 = object2.Position;
            
            Rectangle one = new Rectangle((int)holder1.X, (int)holder1.Y, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Width * 2, object1.sprite.SourceRect[object1.sprite.CurrentFrame].Height * 2);
            Rectangle two = new Rectangle((int)holder2.X, (int)holder2.Y, object2.SourceRect[object2.CurrentFrame].Width * 2, object2.SourceRect[object2.CurrentFrame].Height * 2);
            Rectangle Overlap = Rectangle.Intersect(one, two);
            ColDirections location; //placeholder
            if (Overlap.Width <= Overlap.Height) //this would mean left-right collision
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
