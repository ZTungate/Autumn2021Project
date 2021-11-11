using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class LinkBoomerangProjectile : AbstractProjectile
    {
        Point acceleration;
        public LinkBoomerangProjectile(Point position, Point velocity) : base(position, velocity, ProjectileConstants.boomerangSize)
        {
            Life = 3000;
            //Set the acceleration to be enough to completley reverse velocity over myLife.
            acceleration = new Point(2 * velocity.X / Life, 2 * (velocity.Y / Life));
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