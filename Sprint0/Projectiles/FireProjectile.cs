using Microsoft.Xna.Framework;
using Poggus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class FireProjectile : AbstractProjectile
    {
        Vector2 acceleration;
        Vector2 myVelocity;
        public FireProjectile(Point position, Point velocity) : base(position, velocity, ProjectileConstants.fireSize)
        {
            Life = ProjectileConstants.fireLife;
            //Set the acceleration to be enough to make velocity = 0 by the flame's life is over.
            myVelocity = velocity.ToVector2();
            acceleration = new Vector2(myVelocity.X / Life, myVelocity.Y / Life);
        }
        public override void Update(GameTime gameTime)
        {
            //Move the boomerang according to its velocity.
            DestRect = new Rectangle(DestRect.X + (int)myVelocity.X, DestRect.Y + (int)myVelocity.Y, DestRect.Width, DestRect.Height);
            Sprite.Update(gameTime);

            //Cut the projectile's life by the elapsed time
            int timePassed = gameTime.ElapsedGameTime.Milliseconds;
            Life -= timePassed;
            //Reduce the velocity by the acceleration * elapsed time
            myVelocity -= new Vector2(acceleration.X * (int)timePassed, acceleration.Y * (int)timePassed);
        }
    }
}