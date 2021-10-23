using Microsoft.Xna.Framework;
using Sprint2.Helpers;
using Sprint2.Projectiles;
using Sprint2;
using Sprint2.Enemies;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Dragon : IEnemy
    {
        //ISprite for the enemy
        ISprite mySprite;
        //Position of the dragon.
        Vector2 myPosition;

        //ProjectileHandler for spawning fireballs during an attack
        ProjectileFactory projectiles;

        //Timers for updating sprite without moving
        private int interval = 120;
        private int timer = 0;
        private int attackTimer = 0;
        private int attackInterval = 4000;
        public ISprite Sprite
        {
            //Allow sprite to be set by the spriteFactory, and return mySprite when requested.
            get => mySprite;
            set => mySprite = value;
        }
        public Vector2 Position
        {
            get => myPosition;
            set => myPosition = value;
        }

        public EnemyTypes Type
        {
            //Return Dragon if type is ever asked for.
            get => EnemyTypes.Dragon;
        }

        public void Update(GameTime gameTime)
        {
            //Update the sprite
            mySprite.Update(gameTime);
            //Timer to prevent from moving too fast, should unify with the timer in sprite.Update();
            if (timer < interval)
            {
                timer += gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                timer = 0;
                myPosition = DragonMove();
                mySprite.Position = myPosition;
            }

            if(attackTimer < attackInterval)
            {
                attackTimer += gameTime.ElapsedGameTime.Milliseconds;
            }
            else
            {
                attackTimer = 0;
                Attack();
            }
        }
        public Dragon(ProjectileFactory projectileHandler)
        { 
            //Assign an arbitrary starting positon for the bat.
            myPosition = new Vector2(500, 300);
            projectiles = projectileHandler;
        }

        public Vector2 DragonMove()
        {
            //Initialize an RNG to randomly move the dragon.
            Random rand = new Random();
            Vector2 newPosition = myPosition;
            int val = rand.Next(3);

            //1/3 chance to move forwards, 1/3 chance to move back, and 1/3 chance to do nothing.
            if (val == 0)
            {
                newPosition.X += 5;
            }
            else if (val == 1)
            {
                newPosition.X -= 5;
            }
                return newPosition;
        }

        public void Attack()
        {
            //Generate three fireballs starting at the dragon's location.
            projectiles.NewFireBall(myPosition, new Vector2(-3, -2)); //This one moves up and left.
            projectiles.NewFireBall(myPosition, new Vector2(-3, 0)); //This one moves straight left.
            projectiles.NewFireBall(myPosition, new Vector2(-3, 2)); //This one moves down and left.
        }
    }
}
