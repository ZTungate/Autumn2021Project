using Microsoft.Xna.Framework;
using Poggus;
using Poggus.Helpers;
using Poggus.Player;
using System;
using System.Collections.Generic;
using System.Text;

namespace Poggus.Projectiles
{
    public class LinkBoomerangProjectile : AbstractProjectile
    {
        Point acceleration;
        ILink myLink;
        public LinkBoomerangProjectile(Point position, Point velocity, ILink link) : base(position, velocity, ProjectileConstants.boomerangSize)
        {
            myLink = link;
            calcAcceleration();
            Life = 1;
        }
        public override void Update(GameTime gameTime)
        {
            //Move the boomerang according to its velocity.
            DestRect = new Rectangle(DestRect.Location + Velocity, DestRect.Size);
            Sprite.Update(gameTime);
            calcAcceleration();

            //Cut the projectile's life by the elapsed time
            int timePassed = gameTime.ElapsedGameTime.Milliseconds;

            //Reduce the velocity by the acceleration * elapsed time
            Velocity -= acceleration;
        }

        private void calcAcceleration()
        {
            Point linkCenter = LocationHelpers.GetCenter(myLink.DestRect);
            Point myCenter = LocationHelpers.GetCenter(DestRect);
            Point distance = myCenter - linkCenter;
            acceleration = distance / ProjectileConstants.linkBoomerangMaxVelocity;
            if (acceleration.X > ProjectileConstants.linkBoomerangMaxVelocity.X)
            {
                acceleration.X = ProjectileConstants.linkBoomerangMaxVelocity.X;
            }
            if(acceleration.Y > ProjectileConstants.linkBoomerangMaxVelocity.Y)
            {
                acceleration.Y = ProjectileConstants.linkBoomerangMaxVelocity.Y;
            }

        }
    }
}