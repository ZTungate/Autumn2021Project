using Microsoft.Xna.Framework;
using Sprint2.Helpers;
using Sprint2.Projectiles;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint2.Enemies
{
    public class Thrower : IEnemy
    {
        //Sprite for the enemy
        ISprite mySprite;
        //Position vector
        Vector2 pos;
        //State
        public IEnemyState currState;
        //Projectile controller
        ProjectileFactory projectiles;
        //Timer for throwing projectiles and waiting to update while the boomerang is out.
        int wait = 0;
        int throwDelay = 4000;


        Vector2 IEnemy.Position
        {
            get => pos;
            set => pos = value;
        }
        ISprite IEnemy.Sprite 
        {
            get => mySprite;
            set => mySprite = value;
        }

        EnemyTypes IEnemy.Type
        {
            //Return boomerangThrower as type if requested
            get => EnemyTypes.Thrower;
        }

        void IEnemy.Update(GameTime gameTime)
        {
            //Only update the sprite and movement if we are not waiting for the boomerang to return.
            if (wait <= 0)
            {
                //Get the current frame of animation, set the sprite position to the enemy position, and update the sprite.
                int lastFrame = mySprite.CurrentFrame;
                mySprite.Position = pos;
                mySprite.Update(gameTime);

                //Update the state
                currState.Update(gameTime, mySprite);

                //Perform a random move if the animation frame changed.
                if (mySprite.CurrentFrame != lastFrame)
                {
                    RandomMove();
                }

                if (throwDelay <= 0)
                {
                    Attack();
                    wait = 3000; //Set the thrower to wait 3 seconds (the life of a boomerang)
                    throwDelay = 4000;//Reset the delay
                }
                else
                {
                    throwDelay -= gameTime.ElapsedGameTime.Milliseconds;
                }
            }
            else
            {
                //If we are still waiting for a projectile to return, reduce the timer by the elapsed time.
                wait -= gameTime.ElapsedGameTime.Milliseconds;
            }
        }
        
        public Thrower(ProjectileFactory projectileFactory)
        {
            //Default a new thrower as a left thrower
            currState = new LeftThrower(mySprite, this);
            //Assign an arbitrary starting positon for the thrower
            pos = new Vector2(500, 300);
            //Pass the projectile handler in
            projectiles = projectileFactory;
        }

        private void RandomMove()
        {
            //Get a random number from 0 to 9
            Random rand = new Random();
            int value = rand.Next(10);

            //Change directions or move based on the random number
            if(value == 0)
            {
                currState = new UpThrower(mySprite, this);
                currState.TurnUp();
            }
            else if(value == 1)
            {
                currState = new DownThrower(mySprite, this);
                currState.TurnDown();
            }
            else if(value == 2)
            {
                currState = new RightThrower(mySprite, this);
                currState.TurnRight();
            }
            else if(value == 3)
            {
                currState = new LeftThrower(mySprite, this);
                currState.TurnLeft();
            }
            else 
            {
                currState.MoveForward();
            }

        }
        private void Attack()
        {
            //Create a new boomerang moving the direction given at 3 pixels per tick.
            projectiles.NewBoomerang(pos, 3 * currState.AttackDirection());
        }


    }
}
