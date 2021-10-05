﻿using Microsoft.Xna.Framework;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Projectiles
{
    public class BombProjectile : IProjectile
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
        }

        public void Update(GameTime gameTime)
        {
            //Move the boomerang according to its velocity.
            mySprite.Position = Position;

            mySprite.Update(gameTime);

            //Cut the projectile's life by the elapsed time
            int timePassed = gameTime.ElapsedGameTime.Milliseconds;
            myLife -= timePassed;

        }

        public BombProjectile(Vector2 position)
        {
            //Set the velocity and position to the passed values.
            myPosition = position;
            //Boomerangs have a life of 3 seconds. (could be changed).
            myLife = 1000;

        }
    }
}
