using Microsoft.Xna.Framework;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Projectiles
{
    public class FireballProjectile : IProjectile
    {
        //Fields for storing the sprite, velocity, and position.
        private ISprite mySprite;
        private Vector2 myPosition;
        private Vector2 myVelocity;
        private int myLife;
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
            set => myLife = value;

        }

        public void Update(GameTime gameTime)
        {
            //Move the fireball according to its velocity.
            myPosition += myVelocity;
            mySprite.Position = Position;
            mySprite.Update(gameTime);

            myLife -= gameTime.ElapsedGameTime.Milliseconds;
        }

        public FireballProjectile(Vector2 position, Vector2 velocity)
        {
            //Set the velocity and position to the passed values.
            myPosition = position;
            myVelocity = velocity;
            //Fireballs have a life of 4 seconds (measured in milliseconds, could be changed).
            myLife = 4000;
        }
    }
}
