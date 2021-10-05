using Microsoft.Xna.Framework;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Projectiles
{
    public class BoomerangProjectile : IProjectile
    {
        //Fields for storing the sprite, velocity, and position.
        private ISprite mySprite;
        private Vector2 myPosition;
        private Vector2 myVelocity;
        private int myLife;
        //Boomerang will require acceleration to turn around and come back
        private Vector2 accelleration;
        public ISprite Sprite
        {
            get => mySprite;
            set => mySprite = value;
        }
        public Vector2 Position
        {
            get => myPosition;
            set => myPosition = value;
        }
        public Vector2 Velocity
        {
            get => myVelocity;
            set => myVelocity = value;
        }
        public int Life
        {
            get => myLife;
        }

        public void Update(GameTime gameTime)
        {
            //Move the boomerang according to its velocity.
            myPosition += myVelocity;
            mySprite.Position = Position;
            mySprite.Update(gameTime);

            //Cut the projectile's life by the elapsed time
            int timePassed = gameTime.ElapsedGameTime.Milliseconds;
            myLife -= timePassed;
            //Reduce the velocity by the acceleration * elapsed time
            Velocity -= (accelleration * (int)timePassed);
        }

        public BoomerangProjectile(Vector2 position, Vector2 velocity)
        {
            //Set the velocity and position to the passed values.
            myPosition = position;
            myVelocity = velocity;
            //Boomerangs have a life of 3 seconds. (could be changed).
            myLife = 3000;
            //Set the acceleration to be enough to completley reverse velocity over myLife.
            accelleration = 2 * (velocity / myLife);
        }
    }
}