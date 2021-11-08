using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class FireProjectile : AbstractProjectile
    {
        Point acceleration;
        public FireProjectile(Point position, Point velocity) : base(position, velocity, new Point(0,0))
        {
            //Boomerangs have a life of 3 seconds. (could be changed).
            Life = 1000;
            //Set the acceleration to be enough to completley reverse velocity over myLife.
            acceleration = new Point(velocity.X / Life, velocity.Y / Life);
        }
        public override void Update(GameTime gameTime)
        {
            //Move the boomerang according to its velocity.
            DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);
            Sprite.Update(gameTime);

            //Cut the projectile's life by the elapsed time
            int timePassed = gameTime.ElapsedGameTime.Milliseconds;
            Life -= timePassed;
            //Reduce the velocity by the acceleration * elapsed time
            Velocity -= new Point(acceleration.X * (int)timePassed, acceleration.Y * (int)timePassed);
        }
    }
}