using Microsoft.Xna.Framework;
using Sprint0.Helpers;
using Sprint0.Projectiles;
using Sprint2;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sprint0.Enemies
{
    public class Thrower : IEnemy
    {
        //Sprite for the enemy
        ISprite mySprite;
        //Position vector
        Vector2 pos;
        //State
        IEnemyState currState;
        //Projectile controller
        ProjectileFactory projectiles;
        IEnemyState IEnemy.State
        {
            get => currState;
            set => currState = value;
        }

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
            //Get the current frame of animation, set the sprite position to the enemy position, and update the sprite.
            int lastFrame = mySprite.CurrentFrame;
            mySprite.Position = pos;
            mySprite.Update(gameTime);

            //Update the state
            currState.Update(gameTime, mySprite);
            
            //Perform a random move if the animation frame changed.
            if(mySprite.CurrentFrame != lastFrame)
            {
                RandomMove();
            }
        }
        
        public Thrower(ProjectileFactory projectileHandler)
        {
            //Default a new thrower as a left thrower
            currState = new LeftThrower(mySprite, this);
            //Assign an arbitrary starting positon for the thrower
            pos = new Vector2(500, 300);
            //Pass the projectile handler in
            projectiles = projectileHandler;
        }

        private void RandomMove()
        {
            //Get a random number from 0 to 9
            Random rand = new Random();
            int value = rand.Next(10);

            //Change directions or move based on the random number
            if(value == 0)
            {
                currState.turnUp();
            }
            else if(value == 1)
            {
                currState.turnDown();
            }
            else if(value == 2)
            {
                currState.turnRight();
            }
            else if(value == 3)
            {
                currState.turnLeft();
            }
            else 
            {
                currState.moveForward();
            }

        }



    }
}
